import React, { useEffect, useState } from 'react';
import '../styles/LandingPage.css';
import { useNavigate } from 'react-router-dom';
import Navbar from '../components/Navbar'; // 1. Импортируем наш новый навбар

const LandingPage = () => {
    const [topFlowers, setTopFlowers] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        fetch('https://localhost:7199/api/flowers')
            .then(res => {
                if (!res.ok) throw new Error('Ошибка сети');
                return res.json();
            })
            .then(data => setTopFlowers(data.slice(0, 3)))
            .catch(err => console.log("Бэкенд пока недоступен:", err));
    }, []);

    return (
        <div className="landing-container">
            {/* 2. Заменяем старый <nav> на наш новый динамический компонент */}
            <Navbar />

            <header className="hero-section">
                <h1 className="hero-title">Цветы с интеллектом</h1>
                <p className="hero-subtitle">Свежайшие букеты в Ростове, отобранные нашей нейросетью</p>
                <button className="btn-main" onClick={() => navigate('/showcase')}>
                    Смотреть витрину
                </button>
            </header>

            <section className="info-section">
                <div className="info-card"><h3>📍 Мы рядом</h3><p>ул. Пушкинская, 12</p></div>
                <div className="info-card"><h3>⏰ Работаем</h3><p>09:00 - 21:00</p></div>
                <div className="info-card"><h3>🤖 Smart-контроль</h3><p>Следим за свежестью через ИИ</p></div>
            </section>

            <section className="showcase-section">
                <h2 className="showcase-title">Наши рекомендации</h2>
                <div className="flower-grid">
                    {topFlowers.length > 0 ? (
                        topFlowers.map(flower => (
                            <div key={flower.id} className="flower-card">
                                <div style={{ fontSize: '50px' }}>🌸</div>
                                <h3 className="flower-name">{flower.name}</h3>
                                <p className="flower-variety">{flower.variety}</p>
                                <p className="flower-price">от 450 ₽</p>
                            </div>
                        ))
                    ) : (
                        <p>Загружаем свежие цветы...</p>
                    )}
                </div>
            </section>
        </div>
    );
};

export default LandingPage;