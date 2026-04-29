import { useState } from "react";
import { login } from "../services/authService";

function Login({ onLoginSuccess }) {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const handleLogin = async () => {
        setLoading(true);
        setError("");

        if (!email || !password) {
            setError("Please enter both email and password.");
            setLoading(false);
        }

        try {
            const data = await login(email, password);
            console.log("Login successful:", data);

            onLoginSuccess();
            alert("Login successful!");
        } catch (err) {
            setError("Login failed. Please check your credentials.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h1>Login</h1>
            <div>
                <label>Email:</label>
                <input
                    type='email'
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
            </div>
            <div>
                <label>Password:</label>
                <input
                    type='password'
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                />
            </div>
            <button onClick={handleLogin} disabled={loading}>{loading ? "Logging in..." : "Login"}</button>
            {error && <p style={{ color: 'red' }}>{error}</p>}
        </div>
    );  
}

export default Login;