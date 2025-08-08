import AlbumCard from './AlbumCard.jsx'
import useAlbums from '../hooks/UseAlbums.jsx';

export default function AlbumCardGrid({ albums: propAlbums }) {
    const { albums, error, loading } = useAlbums();
    const displayAlbums = propAlbums || albums;

    if (!propAlbums && loading) return <p>Loading albums...</p>;
    if (!propAlbums && error) return <p>{error}</p>;

    if (displayAlbums.length === 0) {
        return <p>No albums available.</p>;
    }

    return (
        <>
            <div className="container mt-4">
                <div className="row">
                    {displayAlbums.map((album) => (
                        <div className="col-sm-6 col-md-4 col-lg-3 mb-4" key={album.id}>
                            <AlbumCard album={album} />
                        </div>
                    ))}
                </div>
            </div>
        </>
    )
}
