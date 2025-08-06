//list all albums regardless of author

import AlbumCardGrid from "../components/AlbumCardGrid";

//login and register buttons to redirect to those routes.
export default function Homepage() {
    return (
        <>
            <section className="top-banner">
                <h1>MyWebAppName</h1>
                <div>
                    <button>Login</button>
                    <button>Sign Up</button>
                </div></section>

            <AlbumCardGrid />
        </>
    )
}
