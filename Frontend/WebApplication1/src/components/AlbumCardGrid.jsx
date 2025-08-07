import AlbumCard from './AlbumCard.jsx'
import { useEffect, useState } from 'react'

export default function AlbumCardGrid() {
    const [albums, setAlbums] = useState([])

    useEffect(() => {
        fetch("https://localhost:59834/api/album")
            .then(res => res.json())
            .then(data => {
                console.log("Fetched Data:", data);
                data.forEach((album, index) => {
                    console.log(`Album ${index}:`, album);
                });

                setAlbums(data)
            })
            .catch(err => console.error('Failed to fetch albums:', err))
    }, [])

    return (
        <>
            <div className="container mt-4">
                <div className="row">
                    {albums.map((album, index) => (
                        <div className="col-sm-6 col-md-4 col-lg-3 mb-4" key={index}>
                            <AlbumCard album={album} />
                        </div>
                    ))}
                </div>
            </div>
        </>
    )
}
