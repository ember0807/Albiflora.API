import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Showcase.css';
import Navbar from '../components/Navbar';

const ShowcasePage = () => {
    const [bouquets, setBouquets] = useState([]);
    const navigate = useNavigate();

    const API_BASE_URL = 'https://localhost:7199/api';

    useEffect(() => {
        const fetchBouquets = async () => {
            try {
                // Запрашиваем букеты с нашего нового GET-метода в C#
                const response = await fetch(`${API_BASE_URL}/Bouquets`);
                if (response.ok) {
                    const data = await response.json();
                    setBouquets(data); // Передаем букеты (включая только что загруженные) в стейт
                } else {
                    console.error("Не удалось загрузить букеты с сервера");
                }
            } catch (err) {
                console.error("Ошибка загрузки витрины:", err);
            }
        };
        fetchBouquets();
    }, []);


    return (
        <>
            <Navbar />

            {/* Заменили инлайн-стили на чистые CSS-классы */}
            <div className="showcase-container">
                <header className="showcase-header">
                    <h1 className="showcase-title">🌸 Онлайн-витрина Albiflora</h1>
                    <button className="btn-secondary" onClick={() => navigate('/florist')}>
                        ⬅ Назад в управление
                    </button>
                </header>

                <div className="bouquet-grid">
                    {bouquets.map(b => (
                        <div key={b.id} className="bouquet-card">
                            <img src={b.url} alt={b.name} className="bouquet-img" />
                            <h3 className="bouquet-name">{b.name}</h3>
                            <p className="bouquet-price">{b.price} ₽</p>
                            <button className="btn-order">Заказать</button>
                        </div>
                    ))}
                </div>
            </div>
        </>
    );
};

export default ShowcasePage;