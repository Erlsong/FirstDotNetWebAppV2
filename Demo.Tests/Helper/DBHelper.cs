using Infrastructure.Data; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics; 

namespace Demo.Tests.Helper 
{
    internal class DBHelper
    {
        public static AppDbContext GetDatabase()
        {
            // Configure options for an in-memory database
            var options = new DbContextOptionsBuilder<AppDbContext>()
                // Use a unique name for each test or a known name that EnsureDeleted will clear.
                // "TestDatabase" is a common convention.
                .UseInMemoryDatabase("TestDatabase")
                // Ignore the warning about transactions not being supported by in-memory databases.
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options; 

            // Create a new instance of the DbContext with the in-memory options
            var dbContext = new AppDbContext(options);

            // Ensure the database is deleted and recreated for a clean state before each test.
            // This clears any data from previous test runs.
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated(); // Ensures the schema (tables) are set up in-memory

            return dbContext;
        }
    }
}