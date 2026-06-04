import React, { useEffect, useState, useCallback, startTransition } from 'react';
import '../styles/Dashboard.css';
import { useNavigate } from 'react-router-dom';

const API_BASE_URL = 'https://localhost:7199/api';

const FloristPage = () => {
    const navigate = useNavigate();

    // Динамический ID магазина
    const shopId = localStorage.getItem('shopId') || 3;

    const [inventory, setInventory] = useState([]);
    const [shopData, setShopData] = useState({ tariffPlan: 0, isActive: false });

    const [isAddModalOpen, setIsAddModalOpen] = useState(false);
    const [isBouquetModalOpen, setIsBouquetModalOpen] = useState(false);

    // Состояния для новой поставки
    const [newFlower, setNewFlower] = useState({ name: '', variety: '', quantity: 0, price: 0 });

    const [bouquetName, setBouquetName] = useState('');
    const [bouquetPrice, setBouquetPrice] = useState('');
    const [bouquetPhoto, setBouquetPhoto] = useState(null);

    
    const loadData = useCallback(async () => {
        try {
            const shopRes = await fetch(`${API_BASE_URL}/Shops/${shopId}`);
            if (shopRes.ok) {
                const sData = await shopRes.json();
                startTransition(() => {
                    setShopData({ tariffPlan: sData.tariffPlan, isActive: sData.isSubscriptionActive });
                });
            }

            const invRes = await fetch(`${API_BASE_URL}/Inventory/shop/${shopId}`);
            if (invRes.ok) {
                const invData = await invRes.json();
                startTransition(() => {
                    setInventory(invData);
                });
            }
        } catch (err) {
            console.error("Ошибка синхронизации:", err);
        }
    }, [shopId]); // Функция зависит только от изменения shopId

    // Вызываем loadData внутри useEffect
    useEffect(() => {
        loadData();
    }, [loadData]); 

    const handleAddInventory = async (e) => {
        e.preventDefault();
        const flowerData = {
            ...newFlower,
            shopId: parseInt(shopId)
        };

        try {
            const response = await fetch(`${API_BASE_URL}/Flowers`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(flowerData)
            });

            if (response.ok) {
                alert("Поставка успешно добавлена!");
                setIsAddModalOpen(false);
                loadData();
            } else {
                alert("Ошибка сохранения");
            }
        } catch (err) {
            console.error("Ошибка:", err);
        }
    };

    const handleAction = async (id, type) => {
        const qty = type === 'sale' ? prompt("Введите количество:", "1") : 1;
        if (!qty || isNaN(qty)) return;

        try {
            await fetch(`${API_BASE_URL}/Inventory/${type}/${id}`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parseInt(qty))
            });
            loadData();
        } catch (err) {
            console.error(err);
        }
    };

    const handleCreateBouquet = async (e) => {
        e.preventDefault();
        const formData = new FormData();
        formData.append('name', bouquetName);
        formData.append('price', bouquetPrice);
        formData.append('photo', bouquetPhoto);
        formData.append('shopId', shopId);

        try {
            const response = await fetch(`${API_BASE_URL}/Bouquets/upload`, {
                method: 'POST',
                body: formData
            });
            if (response.ok) {
                alert("Букет на витрине!");
                setIsBouquetModalOpen(false);
                setBouquetName('');
                setBouquetPrice('');
                setBouquetPhoto(null);
            }
        } catch (error) {
            console.error(error);
        }
    };

    const hasAiAccess = shopData.isActive && shopData.tariffPlan >= 1;

    return (
        <div className="dashboard-container">
            <aside className="sidebar">
                <div className="sidebar-logo">🌸 Albiflora</div>
                <nav className="sidebar-nav">
                    <button className="active">📦 Склад и Остатки</button>
                    <button className="nav-btn">💐 Конструктор букетов</button>
                    <button className="nav-btn">📊 Отчеты по выручке</button>
                    <button className={!hasAiAccess ? "nav-ai locked" : "nav-ai"}>
                        ✨ ИИ Прогноз {!hasAiAccess && "🔒"}
                    </button>
                </nav>
            </aside>

            <main className="dashboard-main">
                <header className="dashboard-header">
                    <div className="header-info">
                        <h2>Оперативное управление</h2>
                        <span className="status-badge">Магазин ID: {shopId}</span>
                    </div>
                    <div className="header-controls">
                        <button className="btn-secondary" onClick={() => navigate('/showcase')}>📸 Витрина</button>
                        <button className="btn-primary" onClick={() => setIsAddModalOpen(true)}>+ Поставка</button>
                        <button className="btn-bouquet" onClick={() => setIsBouquetModalOpen(true)}>💐 Создать букет</button>
                    </div>
                </header>

                {/* МОДАЛЬНОЕ ОКНО ПОСТАВКИ */}
                {isAddModalOpen && (
                    <div className="modal-overlay">
                        <div className="modal-content">
                            <h3>📦 Новая поставка цветов</h3>
                            <form onSubmit={handleAddInventory} className="bouquet-form">
                                <input
                                    type="text" placeholder="Название (Роза, Лилия...)" className="form-input"
                                    onChange={e => setNewFlower({ ...newFlower, name: e.target.value })} required
                                />
                                <input
                                    type="text" placeholder="Сорт" className="form-input"
                                    onChange={e => setNewFlower({ ...newFlower, variety: e.target.value })}
                                />
                                <input
                                    type="number" placeholder="Количество" className="form-input"
                                    onChange={e => setNewFlower({ ...newFlower, quantity: parseInt(e.target.value) })} required
                                />
                                <input
                                    type="number" placeholder="Цена закупки" className="form-input"
                                    onChange={e => setNewFlower({ ...newFlower, price: parseFloat(e.target.value) })} required
                                />
                                <div className="modal-actions">
                                    <button type="button" className="btn-cancel" onClick={() => setIsAddModalOpen(false)}>Отмена</button>
                                    <button type="submit" className="btn-save-bouquet">Принять на склад</button>
                                </div>
                            </form>
                        </div>
                    </div>
                )}

                {/* МОДАЛЬНОЕ ОКНО БУКЕТА */}
                {isBouquetModalOpen && (
                    <div className="modal-overlay">
                        <div className="modal-content bouquet-modal">
                            <h3>🎨 Дизайнер букета</h3>
                            <form onSubmit={handleCreateBouquet} className="bouquet-form">
                                <input type="text" placeholder="Название букета" className="form-input" value={bouquetName} onChange={(e) => setBouquetName(e.target.value)} required />
                                <input type="number" placeholder="Цена продажи" className="form-input" value={bouquetPrice} onChange={(e) => setBouquetPrice(e.target.value)} required />
                                <input type="file" onChange={(e) => setBouquetPhoto(e.target.files[0])} accept="image/*" className="form-input" />
                                <div className="modal-actions">
                                    <button type="button" className="btn-cancel" onClick={() => setIsBouquetModalOpen(false)}>Отмена</button>
                                    <button type="submit" className="btn-save-bouquet">Выставить</button>
                                </div>
                            </form>
                        </div>
                    </div>
                )}

                <section className="inventory-section">
                    <div className="table-card">
                        <table className="inventory-table">
                            <thead>
                                <tr>
                                    <th>Товар / Сорт</th>
                                    <th>Наличие</th>
                                    <th>Цена</th>
                                    {hasAiAccess && <th>ИИ ✨</th>}
                                    <th>Действия</th>
                                </tr>
                            </thead>
                            <tbody>
                                {inventory && inventory.map(item => (
                                    <tr key={item.id}>
                                        <td><strong>{item.flower?.name}</strong> {item.flower?.variety}</td>
                                        <td>{item.quantity} шт.</td>
                                        <td>{item.salePrice} ₽</td>
                                        {hasAiAccess && <td>{item.aiAnalysis?.status}</td>}
                                        <td>
                                            <button onClick={() => handleAction(item.id, 'sale')}>💰</button>
                                            <button onClick={() => handleAction(item.id, 'waste')}>🗑️</button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                </section>
            </main>
        </div>
    );
};

export default FloristPage;