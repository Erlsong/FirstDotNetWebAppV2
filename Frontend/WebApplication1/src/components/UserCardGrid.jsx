import UserCard from './UserCard.jsx'
import { useEffect, useState } from 'react'
export default function UserCardGrid() {
    const [users, setUsers] = useState([])

    useEffect(() => {
        fetch("https://localhost:59834/api/author")
            .then(res => res.json())
            .then(data => {
                console.log(`Fetched Data: ${data}`);
                setUsers(data)
            })
            .catch(err => console.error('Failed to fetch users:', err))
    }, [])

    return (
        <>
            <div className="user-grid card-grid">
                {users.map((user, index) => (
                    <UserCard key={index} user={user} />
                ))}
            </div>
        </>
    )
}
