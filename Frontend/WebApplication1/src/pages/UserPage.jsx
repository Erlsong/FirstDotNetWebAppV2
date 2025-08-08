import React from "react";
import { useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";

import AlbumCard from "../components/AlbumCard";
import AlbumCardGrid from "../components/AlbumCardGrid";
import TopBanner from "../components/TopBanner";
//UserCard, banner with "Posts", "Albums", Comments
//Render a grid of cards based on what the banner selects.
export default function UserPage() {
    const { id } = useParams();
    const [user, setUser] = useState(null);
    const [albums, setAlbums] = useState([]);
    const [posts, setPosts] = useState([]);
    const [comments, setComments] = useState([]);
    const [view, setView] = useState("albums");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchUser = async () => {
            try {
                const res = await fetch(`https://localhost:59834/api/user-page/${id}`);

                if (!res.ok) {
                    throw new Error(`Error: ${res.status}`);
                }

                const data = await res.json();
                console.log(data);

                setUser(data);
                setAlbums(data.albums);
                setPosts(data.posts);
                setComments(data.comments);

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
        <>
            <TopBanner></TopBanner>
            {user ? (
                <>
                    <div>
                        <h2>{user.penName}</h2>
                        <p><strong>Email:</strong> {user.email}</p>
                    </div>
                    <div>
                        <button>Albums</button>
                        <button>Posts</button>
                        <button>Comments</button>
                    </div>
                    <div>
                        <AlbumCardGrid albums={albums} />
                    </div>
                </>
            ) : (
                <p>User not found.</p>
            )}
        </>
    );
}
