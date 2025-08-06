import reactLogo from '../assets/react.svg'
export default function UserCard({ user }) {
    return (
        <div className="user-card">
            <img src={reactLogo} alt={`img`} />
            <h3>{user.PenName}</h3>
            <p>{user.email}</p>
        </div>
    )
}
