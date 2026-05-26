import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/Showcase.css';
import Navbar from '../components/Navbar';

const ShowcasePage = () => {
    const [bouquets, setBouquets] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        const fetchBouquets = async () => {
            try {
                const mockBouquets = [
                    { id: 1, name: "Весенний нектар", price: 2500, url: "https://placehold.co/250x250/fce4ec/d46a7e?text=Bouquet+1" },
                    { id: 2, name: "Ростовская роза", price: 3800, url: "https://placehold.co/250x250/fce4ec/d46a7e?text=Bouquet+2" }
                ];
                setBouquets(mockBouquets);
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