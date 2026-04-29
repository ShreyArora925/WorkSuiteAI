import { useState } from 'react';
import { searchJobs } from '../services/jobService';

function JobAgent() {
    // Search form inputs
    const [location, setLocation] = useState("Toronto, ON");
    const [keywords, setKeywords] = useState(".NET Developer");
    const [minSalary, setMinSalary] = useState("80000");
    const [maxResults, setMaxResults] = useState("10");

    // Results and UI state
    const [results, setResults] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState("");
    const [selectedJob, setSelectedJob] = useState(null);

    const handleSearch = async () => {
        setLoading(true);
        setError("");
        setResults([]);

        try {
            const searchRequest = {
                location: location,
                keywords: keywords,
                salary: {
                    min: parseInt(minSalary) || 0,
                    max: 0
                },
                experienceLevel: "",
                maxResults: parseInt(maxResults) || 10,
                postedWithinDays: 0
            };

            console.log("Serching with:", searchRequest);

            const data = await searchJobs(searchRequest);
            console.log("Search results:", data);


            setResults(data.matches || []);
        } catch (err) {
            console.error("Search error:", err);
            setError("Failed to search for jobs. Please try again.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
            <h1>🤖 AI Job Agent</h1>
            <p>Find your perfect .NET job with AI-powered matching</p>

            {/* Search Form */}
            <div style={{
                background: '#f5f5f5',
                padding: '20px',
                borderRadius: '8px',
                marginBottom: '30px'
            }}>
                <h2>Search Jobs</h2>

                <div style={{ marginBottom: '15px' }}>
                    <label style={{ display: 'block', marginBottom: '5px', fontWeight: 'bold' }}>
                        Location:
                    </label>
                    <input
                        type="text"
                        value={location}
                        onChange={(e) => setLocation(e.target.value)}
                        placeholder="e.g., Toronto, ON"
                        style={{ width: '100%', padding: '10px', fontSize: '16px' }}
                    />
                </div>

                <div style={{ marginBottom: '15px' }}>
                    <label style={{ display: 'block', marginBottom: '5px', fontWeight: 'bold' }}>
                        Keywords:
                    </label>
                    <input
                        type="text"
                        value={keywords}
                        onChange={(e) => setKeywords(e.target.value)}
                        placeholder="e.g., .NET Developer, C#, ASP.NET Core"
                        style={{ width: '100%', padding: '10px', fontSize: '16px' }}
                    />
                </div>

                <div style={{ marginBottom: '15px' }}>
                    <label style={{ display: 'block', marginBottom: '5px', fontWeight: 'bold' }}>
                        Minimum Salary ($):
                    </label>
                    <input
                        type="number"
                        value={minSalary}
                        onChange={(e) => setMinSalary(e.target.value)}
                        placeholder="80000"
                        style={{ width: '100%', padding: '10px', fontSize: '16px' }}
                    />
                </div>

                <div style={{ marginBottom: '15px' }}>
                    <label style={{ display: 'block', marginBottom: '5px', fontWeight: 'bold' }}>
                        Max Results:
                    </label>
                    <input
                        type="number"
                        value={maxResults}
                        onChange={(e) => setMaxResults(e.target.value)}
                        placeholder="10"
                        style={{ width: '100%', padding: '10px', fontSize: '16px' }}
                    />
                </div>

                <button
                    onClick={handleSearch}
                    disabled={loading}
                    style={{
                        background: '#007bff',
                        color: 'white',
                        padding: '12px 30px',
                        fontSize: '16px',
                        border: 'none',
                        borderRadius: '5px',
                        cursor: loading ? 'not-allowed' : 'pointer',
                        width: '100%'
                    }}
                >
                    {loading ? 'Searching...' : '🔍 Search Jobs'}
                </button>
                <button
                    onClick={() => {
                        setResults([
                            {
                                jobId: 1,
                                title: "Senior .NET Developer",
                                company: "Microsoft",
                                location: "Toronto, ON",
                                salary: { min: 90000, max: 120000 },
                                matchScore: 92,
                                matchReason: "Excellent match! Your C# and ASP.NET Core experience aligns perfectly with this role.",
                                coverLetter: `Dear Hiring Manager,
                                I am writing to express my strong interest in the Senior .NET Developer position at Microsoft. With over 5 years of experience in C#, ASP.NET Core, and enterprise application development, I am confident I would be a valuable addition to your team.

                                In my current role at L&T Infotech, I led the development of an eLogistics system for Otis Elevators, implementing clean architecture principles and CQRS patterns. I optimized SQL Server performance, reducing query times from 800ms to under 150ms while handling 50,000+ daily transactions.
                                
                                My technical expertise includes:
                                - ASP.NET Core, C#, SQL Server
                                - Clean Architecture, CQRS, MediatR
                                - AI Integration (Claude API)
                                - Performance optimization and scalability
                                
                                I am particularly excited about this opportunity at Microsoft because of your commitment to innovation and cutting-edge technology. I would welcome the chance to contribute my skills to your team.
                                
                                Thank you for considering my application.
                                
                                Best regards,
                                Shrey Arora`

                            },
                            {
                                jobId: 2,
                                title: "Full Stack .NET Developer",
                                company: "RBC",
                                location: "Toronto, ON",
                                salary: { min: 85000, max: 110000 },
                                matchScore: 78,
                                matchReason: "Good match. Strong .NET skills, though role requires more frontend experience."
                            }
                        ]);
                    }}
                    style={{
                        background: '#6c757d',
                        color: 'white',
                        padding: '10px 20px',
                        border: 'none',
                        borderRadius: '5px',
                        cursor: 'pointer',
                        marginTop: '10px'
                    }}
                >
                    🧪 Load Test Data
                </button>
            </div>

            {results.length > 0 && (
                <div>
                    <h2>Found {results.length} Jobs</h2>

                    {results.map((job) => (
                        <div
                            key={job.jobId}
                            style={{
                                border: '2px solid #ddd',
                                borderRadius: '8px',
                                padding: '20px',
                                marginBottom: '20px',
                                background: 'white'
                            }}
                        >
                            {/* Match Score Badge */}
                            <div style={{
                                display: 'inline-block',
                                background: job.matchScore >= 80 ? '#28a745' : job.matchScore >= 60 ? '#ffc107' : '#dc3545',
                                color: 'white',
                                padding: '5px 15px',
                                borderRadius: '20px',
                                fontWeight: 'bold',
                                marginBottom: '10px'
                            }}>
                                ⭐ {job.matchScore}% Match
                            </div>

                            {/* Job Title */}
                            <h3 style={{ margin: '10px 0' }}>{job.title}</h3>

                            {/* Company & Location */}
                            <p style={{ color: '#666', margin: '5px 0' }}>
                                <strong>{job.company}</strong> • {job.location}
                            </p>

                            {/* Salary */}
                            {job.salary && (
                                <p style={{ color: '#28a745', margin: '5px 0', fontWeight: 'bold' }}>
                                    💰 ${job.salary.min.toLocaleString()} - ${job.salary.max.toLocaleString()}
                                </p>
                            )}

                            {/* Match Reason */}
                            <p style={{
                                margin: '15px 0',
                                padding: '10px',
                                background: '#f8f9fa',
                                borderRadius: '5px',
                                fontStyle: 'italic'
                            }}>
                                {job.matchReason}
                            </p>

                            {/* Buttons */}
                            <div style={{ marginTop: '15px' }}>
                                <button
                                    onClick={() => setSelectedJob(job)}
                                    style={{
                                        background: '#007bff',
                                        color: 'white',
                                        border: 'none',
                                        padding: '10px 20px',
                                        borderRadius: '5px',
                                        cursor: 'pointer',
                                        marginRight: '10px'
                                    }}
                                >
                                    📝 View Cover Letter
                                </button>

                                <button
                                    style={{
                                        background: '#28a745',
                                        color: 'white',
                                        border: 'none',
                                        padding: '10px 20px',
                                        borderRadius: '5px',
                                        cursor: 'pointer'
                                    }}
                                >
                                    Apply →
                                </button>
                            </div>
                        </div>
                    ))}
                </div>
            )}
            {selectedJob && (
                <div style={{
                    position: 'fixed',
                    top: 0,
                    left: 0,
                    right: 0,
                    bottom: 0,
                    background: 'rgba(0,0,0,0.7)',
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center',
                    zIndex: 1000
                }}>
                    <div style={{
                        background: 'white',
                        padding: '30px',
                        borderRadius: '10px',
                        maxWidth: '700px',
                        maxHeight: '80vh',
                        overflow: 'auto',
                        position: 'relative'
                    }}>
                        {/* Header */}
                        <h2 style={{ marginTop: 0 }}>
                            Cover Letter for {selectedJob.title}
                        </h2>
                        <p style={{ color: '#666', marginBottom: '20px' }}>
                            {selectedJob.company} • {selectedJob.location}
                        </p>

                        {/* Cover Letter Text */}
                        <div style={{
                            background: '#f8f9fa',
                            padding: '20px',
                            borderRadius: '5px',
                            whiteSpace: 'pre-wrap',
                            fontFamily: 'Georgia, serif',
                            lineHeight: '1.6',
                            marginBottom: '20px'
                        }}>
                            {selectedJob.coverLetter || "Generating cover letter..."}
                        </div>

                        {/* Buttons */}
                        <div style={{ display: 'flex', gap: '10px', justifyContent: 'flex-end' }}>
                            <button
                                onClick={() => {
                                    navigator.clipboard.writeText(selectedJob.coverLetter);
                                    alert('Cover letter copied to clipboard!');
                                }}
                                style={{
                                    background: '#28a745',
                                    color: 'white',
                                    border: 'none',
                                    padding: '10px 20px',
                                    borderRadius: '5px',
                                    cursor: 'pointer'
                                }}
                            >
                                📋 Copy to Clipboard
                            </button>

                            <button
                                onClick={() => {
                                    // Create download
                                    const blob = new Blob([selectedJob.coverLetter], { type: 'text/plain' });
                                    const url = URL.createObjectURL(blob);
                                    const link = document.createElement('a');
                                    link.href = url;
                                    link.download = `CoverLetter_${selectedJob.company}.txt`;
                                    link.click();
                                    URL.revokeObjectURL(url);
                                }}
                                style={{
                                    background: '#007bff',
                                    color: 'white',
                                    border: 'none',
                                    padding: '10px 20px',
                                    borderRadius: '5px',
                                    cursor: 'pointer'
                                }}
                            >
                                💾 Download
                            </button>

                            <button
                                onClick={() => setSelectedJob(null)}
                                style={{
                                    background: '#dc3545',
                                    color: 'white',
                                    border: 'none',
                                    padding: '10px 20px',
                                    borderRadius: '5px',
                                    cursor: 'pointer'
                                }}
                            >
                                ✕ Close
                            </button>
                        </div>
                    </div>
                </div>
            )}

            {!loading && results.length === 0 && (
                <p style={{ textAlign: 'center', color: '#666', marginTop: '40px' }}>
                    No jobs found. Try searching above!
                </p>
            )}
            {error && <p style={{ color: 'red' }}>{error}</p>}
        </div>
    );
}

export default JobAgent;