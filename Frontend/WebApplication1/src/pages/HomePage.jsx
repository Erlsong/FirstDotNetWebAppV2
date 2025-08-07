//list all albums regardless of author

import { useNavigate } from "react-router-dom";
import AlbumCardGrid from "../components/AlbumCardGrid";
import TestingNav from "../components/TestingNav";

//login and register buttons to redirect to those routes.
export default function Homepage() {
    const nav = useNavigate()
    const navLogin = () => {
        nav('/Login')
    }
    return (
        <>
            <TestingNav></TestingNav>
            <section className="top-banner">
                <h1>MyWebAppName</h1>
                <div>
                    <button onClick={navLogin}>Login</button>
                    <button>Sign Up</button>
                </div></section>

            <AlbumCardGrid />
        </>
    )
}
