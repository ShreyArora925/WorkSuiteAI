import { useState, useEffect } from 'react';
import Login from "./Pages/Login";
import JobAgent from "./Pages/JobAgent";

function App() {
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    // Check if user has token when app loads
    useEffect(() => {
        const token = localStorage.getItem('token');
        if (token) {
            setIsLoggedIn(true);
        }
    }, []);

    // Handle successful login
    const handleLoginSuccess = () => {
        setIsLoggedIn(true);
    };

    // Handle logout
    const handleLogout = () => {
        localStorage.removeItem('token');
        setIsLoggedIn(false);
    };

    // If not logged in, show Login page
    if (!isLoggedIn) {
        return <Login onLoginSuccess={handleLoginSuccess} />;
    }

    // If logged in, show JobAgent with logout button
    return (
        <div>
            <div style={{
                background: '#333',
                color: 'white',
                padding: '10px 20px',
                display: 'flex',
                justifyContent: 'space-between',
                alignItems: 'center'
            }}>
                <h2>WorkSuiteAI</h2>
                <button
                    onClick={handleLogout}
                    style={{
                        background: '#dc3545',
                        color: 'white',
                        border: 'none',
                        padding: '8px 16px',
                        borderRadius: '4px',
                        cursor: 'pointer'
                    }}
                >
                    Logout
                </button>
            </div>
            <JobAgent />
        </div>
    );
}

export default App;