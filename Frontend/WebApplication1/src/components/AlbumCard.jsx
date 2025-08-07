import reactLogo from '../assets/react.svg'

export default function AlbumCard({ album }) {
    return (
        <div className="album-card card">
            <img src={reactLogo} alt={`img`} className="card-img-top" />
            <div className="card-body">
                <h5 className="card-title">{album.name}</h5>
                <p>By: User{album.userId}</p>
                <p className="card-text">{album.description}</p>
                <button className="btn btn-primary">View</button>
            </div>
        </div>
    )
}
