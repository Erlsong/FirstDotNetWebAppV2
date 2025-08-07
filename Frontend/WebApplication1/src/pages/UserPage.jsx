import React from "react";
import { useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
//UserCard, banner with "Posts", "Albums", Comments
//Render a grid of cards based on what the banner selects.
export default function UserPage() {
    const { id } = useParams();
    const [user, setUser] = useState(null);
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchUser = async () => {
            try {
                const res = await fetch(`https://localhost:59834/api/user/${id}`);

                if (!res.ok) {
                    throw new Error(`Error: ${res.status}`);
                }

                const data = await res.json();
                setUser(data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchUser();
    }, [id]);

    if (loading) return <p>Loading user data...</p>;
    if (error) return <p style={{ color: "red" }}>Error: {error}</p>;

    return (
        <div style={{ maxWidth: "600px", margin: "auto", padding: "1em" }}>
            <h2>User Profile</h2>
            {user ? (
                <div>
                    <p><strong>Pen Name:</strong> {user.penName}</p>
                    <p><strong>Email:</strong> {user.email}</p>
                </div>
            ) : (
                <p>User not found.</p>
            )}
        </div>
    );
}
