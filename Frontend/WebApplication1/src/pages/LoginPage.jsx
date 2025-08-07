import { useState } from "react";
import TestingNav from "../components/TestingNav";
import { useNavigate } from "react-router-dom";

export default function LoginPage() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const nav = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();

        try {
            const res = await fetch("https://localhost:59834/api/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ email, password }),
            });

            if (!res.ok) {
                throw new Error("Invalid credentials");
            }

            const data = await res.json();

            console.log("Login successful", data);
        } catch (err) {
            setError(err.message);
        }
    };

    const navRegister = () => { nav('/Register') }

    return (
        <>
            <TestingNav />
            <form onSubmit={handleLogin}>
                <div className="form-group">
                    <label>Email</label>
                    <input
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className="form-control"
                        type="email"
                        required
                    />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="form-control"
                        type="password"
                        required
                    />
                </div>

                {error && <div style={{ color: "red" }}>{error}</div>}

                <div style={{ marginTop: "1em" }}>
                    <button type="submit" className="btn btn-primary">Login</button>
                    <button
                        type="button"
                        className="btn btn-secondary"
                        onClick={navRegister}
                        style={{ marginLeft: "1em" }}
                    >
                        Register
                    </button>
                </div>
            </form>
        </>
    );
}
