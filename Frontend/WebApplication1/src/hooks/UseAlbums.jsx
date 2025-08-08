import { useState, useEffect } from "react";

export default function useAlbums() {
    const [albums, setAlbums] = useState([]);
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetch("https://localhost:59834/api/album")
            .then(res => {
                if (!res.ok) {
                    throw new Error(`HTTP error! status: ${res.status}`);
                }
                return res.json();
            })
            .then(data => {
                setAlbums(data);
                setLoading(false);
            })
            .catch(err => {
                console.error('Failed to fetch albums:', err);
                setError("Error Loading Albums");
                setLoading(false);
            });
    }, []);

    return { albums, error, loading };
}
