import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const Navbar = () => {
    const navigate = useNavigate();
    const { user, logout } = useAuth();

    const handleLogout = () => {
        logout();
        localStorage.removeItem('shopId');
        navigate('/');
    };

    return (
        <nav className="navbar">
            <div className="logo" onClick={() => navigate('/')} style={{ cursor: 'pointer' }}>
                🌸 Albiflora
            </div>
            <div className="nav-buttons">
                {/* Если пользователь ГОСТЬ */}
                {!user && (
                    <>
                        <button className="btn-login" onClick={() => navigate('/login')}>
                            Вход
                        </button>
                        <button className="btn-register" onClick={() => navigate('/register')}>
                            Регистрация
                        </button>
                    </>
                )}

                {/* Если пользователь АВТОРИЗОВАН */}
                {user && (
                    <>
                        <button className="btn-nav-item" onClick={() => navigate('/showcase')}>
                            🏪 Витрина
                        </button>

                        {/* Кнопки Директора */}
                        {user.role === 'Admin' && (
                            <>
                                <button className="btn-nav-admin" onClick={() => navigate('/admin')} style={{ fontWeight: 'bold', color: '#ff69b4' }}>
                                    👑 Панель Директора
                                </button>
                                <button className="btn-nav-item" onClick={() => navigate('/florist')}>
                                    📦 Склад
                                </button>
                            </>
                        )}

                        {/* Кнопки Флориста */}
                        {user.role === 'Florist' && (
                            <button className="btn-nav-item" onClick={() => navigate('/florist')}>
                                💐 Мой Склад
                            </button>
                        )}

                        <button className="btn-logout" onClick={handleLogout} style={{ marginLeft: '10px' }}>
                            Выйти ({user.role})
                        </button>
                    </>
                )}
            </div>
        </nav>
    );
};

export default Navbar;