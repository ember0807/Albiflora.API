import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Auth.css';
import { useAuth } from '../context/AuthContext';

// 1. Выносим адрес API в константу
const API_BASE_URL = 'https://localhost:7199/api';

const LoginPage = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();
    const { login } = useAuth();

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            // Используем API_BASE_URL вместо прямого текста
            const response = await fetch(`${API_BASE_URL}/Auth/login`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ email, password })
            });

            if (response.ok) {
                const data = await response.json();

                // 1. Сохраняем shopId в localStorage ПЕРЕД переходом
                if (data.shopId) {
                    localStorage.setItem('shopId', data.shopId);
                } else {
                    localStorage.removeItem('shopId'); // Очищаем старый, если зашел юзер без магазина
                }

                // 2. ВАЖНО: Сохраняем данные тарифа и подписки для Панели Директора
                localStorage.setItem('tariffPlan', data.tariffPlan ?? 0);
                localStorage.setItem('isSubscriptionActive', data.isSubscriptionActive ?? false);

                login(data.token, data.role);

                // 3. Перенаправляем в зависимости от роли
                if (data.role === 'Admin') {
                    // Директора сразу отправляем рулить сетью в админку
                    navigate('/admin');
                } else if (data.role === 'Florist') {
                    // Флориста отправляем на склад / к букетам
                    navigate('/florist');
                } else {
                    // Обычного клиента — на витрину магазина
                    navigate('/showcase');
                }
            } else {
                alert("Неверный логин или пароль");
            }

        } catch (err) {
            console.error("Ошибка авторизации:", err);
            alert("Сервер недоступен. Проверьте запуск бэкенда.");
        }
    };

    return (
        <div className="auth-container">
            <div className="auth-card">
                <div className="auth-logo" onClick={() => navigate('/')} style={{ cursor: 'pointer' }}>
                    🌸 Albiflora
                </div>
                <h2 className="auth-title">Вход в систему</h2>

                <form onSubmit={handleLogin} className="auth-form">
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

                    <button type="submit" className="btn-auth">Войти</button>
                </form>

                <div className="auth-options">
                    {/* 3. ОЖИВЛЯЕМ КНОПКУ РЕГИСТРАЦИИ */}
                    <p>
                        Нет аккаунта?{' '}
                        <span
                            className="auth-link"
                            onClick={() => navigate('/register')}
                            style={{ cursor: 'pointer', color: '#ff69b4' }}
                        >
                            Зарегистрироваться
                        </span>
                    </p>
                    <p className="auth-link-small">Забыли пароль?</p>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
