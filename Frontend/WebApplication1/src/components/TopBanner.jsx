import { useNavigate } from "react-router-dom"
import { Link } from "react-router-dom"
export default function TopBanner() {
    const nav = useNavigate()

    const navLogin = () => {
        nav('/Login')
    }
    const navRegister = () => { nav('/Register') }

    return (<>
        <Link to="/"><h1>MyWebAppName</h1></Link>
        <div>
            <button onClick={navLogin}>Login</button>
            <button onClick={navRegister}>Sign Up</button>
        </div>
    </>)
}
