import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext"
//enter PenName, password (confirm password), email
//make a modal confirming the success or failure
//redirect to homepage
//Login button to redirect to login page
export default function RegisterPage() {
    const [penName, setPenName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');
    const nav = useNavigate();
    const { login } = useAuth();

    const handleSubmit = async (e) => {
        e.preventDefault();

        const requestBody = {
            penName,
            email,
            password,
        };

        try {
            const response = await fetch('https://localhost:59834/api/user', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(requestBody),
            });

            if (!response.ok) {
                const errorText = await response.text();
                setMessage(`Error: ${errorText}`);
            } else {
                const data = await response.json();
                login(data);
                console.log(`User created successfully: ${JSON.stringify(data)}`);
                nav('/');
            }
        } catch (error) {
            console.error('Request failed', error);
            setMessage('Request failed. Please try again later.');
        }
    };

    return (
        <div style={{ maxWidth: '400px', margin: 'auto' }}>
            <h2>Create User</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Pen Name:</label>
                    <input
                        type="text"
                        value={penName}
                        onChange={(e) => setPenName(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Register</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
};
