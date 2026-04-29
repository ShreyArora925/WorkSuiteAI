const API_URL = 'http://localhost:5286';

export const searchJobs = async (props) => {

    const response = await fetch(`${API_URL}/api/jobagent/search`, {
        method: 'POST',
        headers: {
            'Content-Type' : 'application/json',
        },
        body: JSON.stringify(props)

    });
    if (!response.ok) {
        throw new Error('Job search failed');
    }

    const data = await response.json();
    return data;
}