//list all albums regardless of author

import { useNavigate } from "react-router-dom";
import AlbumCardGrid from "../components/AlbumCardGrid";
import TestingNav from "../components/TestingNav";
import TopBanner from "../components/TopBanner";

//login and register buttons to redirect to those routes.
export default function Homepage() {
    return (
        <>
            <TestingNav />
            <TopBanner />
            <AlbumCardGrid />
        </>
    )
}
