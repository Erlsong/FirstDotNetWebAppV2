import reactLogo from '../assets/react.svg'

export default function AlbumCard({ album }) {
    return (
        <div className="album-card card">
            <img src={reactLogo} alt={`img`} />
            <h3>{album.Name}</h3>
            <p>By {album.AuthorId}</p>
            <p>{album.Description}</p>
        </div>
    )
}
