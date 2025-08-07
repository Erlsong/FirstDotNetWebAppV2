import { useNavigate } from "react-router-dom"


export default function TestingNav() {
    const nav = useNavigate()
    const handleNavTest = () => {
        nav('/testing')
    }
    return (
        <button onClick={handleNavTest}>Testing stage</button>
    )
}
