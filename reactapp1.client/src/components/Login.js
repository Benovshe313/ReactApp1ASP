import { useState } from 'react';
import { login } from "../services/authService";

const Login = () => {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleLogin = async (ev) => {
        ev.preventDefault()
        try {
            await login(username, password)
            alert("Login successful!")
        }
        catch {
            alert("Login failed")
        }
    };

    return (
        <form onSubmit={handleLogin}>
            <input type="text" placeholder="Username" value={username} onChange={(ev) => setUsername(ev.target.value)} />
            <input type="password" placeholder="Password" value={password} onChange={(ev) => setPassword(ev.target.value)} />
            <button type="submit">Login</button>
        </form>
    );
};

export default Login;