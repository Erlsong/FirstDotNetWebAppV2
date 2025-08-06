import AlbumCard from './AlbumCard.jsx'
import { useEffect, useState } from 'react'

export default function AlbumCardGrid() {
    const [albums, setAlbums] = useState([])

    useEffect(() => {
        fetch("https://localhost:59834/api/album")
            .then(res => res.json())
            .then(data => {
                console.log(`Fetched Data: ${data}`);
                setAlbums(data)
            })
            .catch(err => console.error('Failed to fetch albums:', err))
    }, [])

    return (
        <>
            <div className="album-grid card-grid">
                {albums.map((album, index) => (
                    <AlbumCard key={index} album={album} />
                ))}
            </div>
        </>
    )
}
