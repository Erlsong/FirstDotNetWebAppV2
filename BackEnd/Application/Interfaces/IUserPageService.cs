using Application.Models.Responses;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserPageService
    {
        Task<UserPageDto> GetUserPageDetailsAsync(int id);   
    
    }
}
