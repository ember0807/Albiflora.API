import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Auth.css';

const API_BASE_URL = 'https://localhost:7199/api';

const RegisterPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const navigate = useNavigate();

    const handleRegister = async (e) => {
        e.preventDefault();

        if (password !== confirmPassword) {
            alert("Пароли не совпадают!");
            return;
        }

        try {
            const response = await fetch(`${API_BASE_URL}/Auth/register`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ email, password })
            });

            if (response.ok) {
                alert("Регистрация успешна! Теперь войдите в систему.");
                navigate('/login');
            } else {
                const errorData = await response.json();
                alert(errorData.message || "Ошибка регистрации");
            }
        } catch (err) {
            console.error("Ошибка при регистрации:", err);
            alert("Не удалось связаться с сервером.");
        }
    };

    return (
        <div className="auth-container">
            <div className="auth-card">
                <div className="auth-logo" onClick={() => navigate('/')} style={{ cursor: 'pointer' }}>
                    🌸 Albiflora
                </div>
                <h2 className="auth-title">Регистрация</h2>

                <form onSubmit={handleRegister} className="auth-form">
                    <div className="input-group">
                        <label>Электронная почта</label>
                        <input
                            type="email"
                            placeholder="example@mail.ru"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </div>

                    <div className="input-group">
                        <label>Пароль</label>
                        <input
                            type="password"
                            placeholder="••••••••"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>

                    <div className="input-group">
                        <label>Подтвердите пароль</label>
                        <input
                            type="password"
                            placeholder="••••••••"
                            value={confirmPassword}
                            onChange={(e) => setConfirmPassword(e.target.value)}
                            required
                        />
                    </div>

                    <button type="submit" className="btn-auth">Создать аккаунт</button>
                </form>

                <div className="auth-options">
                    <p>
                        Уже есть аккаунт?{' '}
                        <span
                            className="auth-link"
                            onClick={() => navigate('/login')}
                            style={{ cursor: 'pointer' }}
                        >
                            Войти
                        </span>
                    </p>
                </div>
            </div>
        </div>
    );
};

export default RegisterPage;
