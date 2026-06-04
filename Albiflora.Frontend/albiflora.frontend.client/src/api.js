
const API_BASE_URL = 'http://130.193.35.154:7199/api';
export const apiRequest = async (endpoint, options = {}) => {
    const token = localStorage.getItem('token');

    const headers = {
        'Content-Type': 'application/json',
        ...options.headers,
    };

    if (token) {
        headers['Authorization'] = `Bearer ${token}`;
    }

    const response = await fetch(`${API_BASE_URL}${endpoint}`, {
        ...options,
        headers,
    });

    if (response.status === 401) {
        // Если токен протух или неверный — разлогиниваем
        localStorage.clear();
        window.location.href = '/login';
        return;
    }

    return response;
};
