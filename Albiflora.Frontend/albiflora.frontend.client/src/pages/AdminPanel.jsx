import React, { useState, useEffect, startTransition, useRef } from 'react';
import '../styles/Admin.css';
import Navbar from '../components/Navbar';
import { YMaps, Map, Placemark, SearchControl } from '@pbe/react-yandex-maps';

const API_BASE_URL = 'https://localhost:7199/api';
const YANDEX_MAPS_API_KEY = '5c06d69a-dc4b-4ddb-94d9-f7f4b747bc9f';

const AdminPanel = () => {
    const [users, setUsers] = useState([]);
    const [shops, setShops] = useState([]);
    const [loading, setLoading] = useState(true);

    const createSearchRef = useRef(null);
    const relocateSearchRef = useRef(null);

    // Управление правами персонала
    const [selectedUserId, setSelectedUserId] = useState(null);
    const [selectedRole, setSelectedRole] = useState('Florist');
    const [selectedShopId, setSelectedShopId] = useState('');

    // Создание магазина
    const [isShopModalOpen, setIsShopModalOpen] = useState(false);
    const [newShop, setNewShop] = useState({
        name: '', address: '', isOwned: false, rentPrice: '', rentPaymentDate: '', utilityBills: ''
    });

    // Переезд магазина
    const [isRelocateModalOpen, setIsRelocateModalOpen] = useState(false);
    const [shopToRelocate, setShopToRelocate] = useState(null);

    // Координаты (центр Ростова-на-Дону)
    const [mapCenter, setMapCenter] = useState([47.222078, 39.720358]);

    // Состояния для VIP-аналитики
    const [selectedShopAnalytics, setSelectedShopAnalytics] = useState(null);
    const [activeAnalyticsShopId, setActiveAnalyticsShopId] = useState(null);
    const [isPaywallOpen, setIsPaywallOpen] = useState(false);

    // Проверка тарифа директора
    const currentDirectorTariff = parseInt(localStorage.getItem('tariffPlan') || '0');
    const isSubscriptionActive = localStorage.getItem('isSubscriptionActive') === 'true';
    const isVipUser = currentDirectorTariff >= 1 && isSubscriptionActive;

    const maxShopsLimit = isVipUser ? 3 : 1;
    const isLimitReached = shops.length >= maxShopsLimit;

    const fetchData = async () => {
        try {
            const [usersRes, shopsRes] = await Promise.all([
                fetch(`${API_BASE_URL}/Admin/users`),
                fetch(`${API_BASE_URL}/Shops`)
            ]);

            if (usersRes.ok && shopsRes.ok) {
                const usersData = await usersRes.json();
                const shopsData = await shopsRes.json();

                startTransition(() => {
                    setUsers(usersData);
                    setShops(shopsData);
                });
            }
        } catch (err) {
            console.error("Ошибка загрузки данных:", err);
        } finally {
            startTransition(() => {
                setLoading(false);
            });
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    // 1. Новая функция: обрабатывает КЛИК МЫШКОЙ по карте
    const handleMapClick = async (e, type) => {
        const coords = e.get('coords'); // Получаем координаты клика [широта, долгота]
        setMapCenter(coords); // Переносим маркер туда, куда кликнули

        try {
            // Запрашиваем у Яндекса текстовый адрес по координатам клика
            const response = await fetch(`https://geocode-maps.yandex.ru/1.x/?apikey=${YANDEX_MAPS_API_KEY}&geocode=${coords[1]},${coords[0]}&format=json&lang=ru_RU`);
            if (response.ok) {
                const data = await response.json();
                const geoObject = data.response.GeoObjectCollection.featureMember[0]?.GeoObject;
                const textAddress = geoObject?.metaDataProperty.GeocoderMetaData.text || 'Точка на карте';

                // Записываем адрес в нужный стейт в зависимости от модалки
                if (type === 'create') {
                    setNewShop(prev => ({ ...prev, address: textAddress }));
                } else if (type === 'relocate') {
                    setShopToRelocate(prev => ({ ...prev, address: textAddress }));
                }
            }
        } catch (err) {
            console.error("Ошибка обратного геокодирования:", err);
        }
    };

    // 2. Обновленная функция: ПОИСК при создании точки
    const handleCreateAddressSelect = () => {
        if (createSearchRef.current) {
            const result = createSearchRef.current.getResultsArray()[0];
            if (result) {
                const geoAddress = result.properties.get('text');
                const coords = result.geometry.getCoordinates();

                setNewShop(prev => ({ ...prev, address: geoAddress }));
                setMapCenter(coords); // Двигаем карту и маркер к найденному адресу
            }
        }
    };

    // 3. Обновленная функция: ПОИСК при переезде точки
    const handleRelocateAddressSelect = () => {
        if (relocateSearchRef.current) {
            const result = relocateSearchRef.current.getResultsArray()[0];
            if (result) {
                const geoAddress = result.properties.get('text');
                const coords = result.geometry.getCoordinates();

                setShopToRelocate(prev => ({ ...prev, address: geoAddress }));
                setMapCenter(coords); // Двигаем карту и маркер к найденному адресу
            }
        }
    };


    const loadShopAnalytics = async (shopId) => {
        if (!isVipUser) {
            setIsPaywallOpen(true);
            return;
        }
        setActiveAnalyticsShopId(shopId);
        try {
            const res = await fetch(`${API_BASE_URL}/Admin/shops/${shopId}/analytics`);
            if (res.ok) {
                const data = await res.json();
                setSelectedShopAnalytics(data);
            }
        } catch (err) {
            console.error("Ошибка аналитики:", err);
        }
    };

    const handleAssign = async (e) => {
        e.preventDefault();
        if (!selectedUserId) return alert("Выберите пользователя!");

        try {
            const response = await fetch(`${API_BASE_URL}/Admin/assign-role`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    userId: selectedUserId,
                    role: selectedRole,
                    shopId: selectedShopId ? parseInt(selectedShopId) : null
                })
            });

            if (response.ok) {
                alert("Права изменены!");
                setSelectedUserId(null);
                fetchData();
            }
        } catch (err) {
            console.error(err);
        }
    };

    const handleCreateShop = async (e) => {
        e.preventDefault();
        if (!newShop.address) return alert("Пожалуйста, выберите точный адрес на карте!");
        if (isLimitReached) return alert("Лимит исчерпан!");

        const shopData = {
            name: newShop.name,
            address: newShop.address,
            licenseKey: `ALBI-${Math.random().toString(36).substr(2, 9).toUpperCase()}`,
            isOwned: newShop.isOwned,
            rentPrice: newShop.isOwned ? 0 : parseFloat(newShop.rentPrice || '0'),
            rentPaymentDate: newShop.isOwned ? null : parseInt(newShop.rentPaymentDate || '0'),
            utilityBills: parseFloat(newShop.utilityBills || '0')
        };

        try {
            const response = await fetch(`${API_BASE_URL}/Admin/shops`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(shopData)
            });

            if (response.ok) {
                alert("Магазин успешно интегрирован в сеть!");
                setIsShopModalOpen(false);
                setNewShop({ name: '', address: '', isOwned: false, rentPrice: '', rentPaymentDate: '', utilityBills: '' });
                fetchData();
            }
        } catch (err) {
            console.error(err);
        }
    };

    const handleRelocateSubmit = async (e) => {
        e.preventDefault();
        if (!shopToRelocate.address) return alert("Выберите новый адрес на карте!");
        try {
            const response = await fetch(`${API_BASE_URL}/Admin/shops/${shopToRelocate.id}/relocate`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    address: shopToRelocate.address,
                    isOwned: shopToRelocate.isOwned,
                    rentPrice: shopToRelocate.isOwned ? 0 : parseFloat(shopToRelocate.rentPrice || '0'),
                    rentPaymentDate: shopToRelocate.isOwned ? null : parseInt(shopToRelocate.rentPaymentDate || '0'),
                    utilityBills: parseFloat(shopToRelocate.utilityBills || '0')
                })
            });

            if (response.ok) {
                alert("Точка успешно переехала!");
                setIsRelocateModalOpen(false);
                fetchData();
            }
        } catch (err) {
            console.error(err);
        }
    };

    const handleCloseShop = async (shopId) => {
        try {
            const response = await fetch(`${API_BASE_URL}/Admin/shops/${shopId}/close`, { method: 'DELETE' });
            if (response.ok) {
                alert("Точка закрыта, персонал переведен в резерв сети.");
                setActiveAnalyticsShopId(null);
                fetchData();
            }
        } catch (err) {
            console.error(err);
        }
    };

    if (loading) return <div className="admin-loading">Загрузка панели директора...</div>;

    return (
        <YMaps query={{ apikey: YANDEX_MAPS_API_KEY, lang: 'ru_RU', load: 'package.full' }}>
            <Navbar />
            <div className="admin-container">
                <header className="admin-header">
                    <h2>Панель Управления Сетью Albiflora</h2>
                    <div className="limit-info-badge">
                        Точки в сети: <strong>{shops.length} / {maxShopsLimit}</strong>
                    </div>
                    <button
                        className={`btn-add-shop ${isLimitReached ? 'disabled' : ''}`}
                        onClick={() => {
                            setMapCenter([47.222078, 39.720358]);
                            setIsShopModalOpen(true);
                        }}
                        disabled={isLimitReached}
                    >
                        {isLimitReached ? "🔒 Лимит исчерпан" : "🏪 + Открыть новую точку"}
                    </button>
                </header>

                {/* МОНИТОРИНГ И АНАЛИЗ */}
                <div className="shops-management-section">
                    <h3>📊 Мониторинг ликвидности и финансового здоровья</h3>
                    <div className="shops-grid">
                        {shops.map(shop => (
                            <div
                                key={shop.id}
                                className={`shop-card-panel ${activeAnalyticsShopId === shop.id ? 'active-shop' : ''} ${!isVipUser ? 'premium-locked' : ''}`}
                                onClick={() => loadShopAnalytics(shop.id)}
                            >
                                <div className="shop-card-header">
                                    <h4>{shop.name}</h4>
                                    {!isVipUser && <span className="lock-icon-badge">👑 VIP AI</span>}
                                </div>
                                <p className="shop-card-address">📍 {shop.address}</p>

                                {isVipUser && activeAnalyticsShopId === shop.id && selectedShopAnalytics ? (
                                    <div className="shop-analytics-data animate-fade-in">
                                        <hr />
                                        <div className="ai-verdict-box">
                                            <h5>🤖 Анализ Albiflora AI:</h5>
                                            <p>Прогноз рентабельности: <strong style={{ color: '#40c057' }}>+15% (Стабильно)</strong></p>
                                            <p className="ai-suggestion">
                                                {shop.isOwned
                                                    ? "Помещение в собственности исключает арендные риски."
                                                    : `Оплата аренды (${shop.rentPrice.toLocaleString()} ₽) предстоит ${shop.rentPaymentDate}-го числа.`}
                                            </p>
                                        </div>
                                        <div className="metric"><span className="label">В смене:</span> <strong className="val-emp">{selectedShopAnalytics.activeEmployee}</strong></div>
                                        <div className="metric"><span className="label">Выручка за месяц:</span> <strong className="val-sales">{selectedShopAnalytics.totalSales.toLocaleString()} ₽</strong></div>
                                        <div className="metric"><span className="label">Фикс. коммуналка:</span> <strong>{shop.utilityBills.toLocaleString()} ₽</strong></div>

                                        <div className="shop-actions-panel">
                                            <button type="button" className="btn-shop-action btn-relocate" onClick={(e) => { e.stopPropagation(); setShopToRelocate(shop); setIsRelocateModalOpen(true); }}>🚚 Переезд точки</button>
                                            <button type="button" className="btn-shop-action btn-close-shop" onClick={(e) => { e.stopPropagation(); if (window.confirm(`Вы уверены, что хотите полностью ЗАКРЫТЬ филиал "${shop.name}"?`)) handleCloseShop(shop.id); }}>🚨 Закрыть филиал</button>
                                        </div>
                                    </div>
                                ) : (
                                    <span className="click-to-view-text">{isVipUser ? "Посмотреть финансовое здоровье" : "Анализ ликвидности и ИИ-прогноз (VIP)"}</span>
                                )}
                            </div>
                        ))}
                    </div>
                </div>

                {/* КАДРЫ */}
                <div className="admin-content">
                    <div className="users-table-section">
                        <h3>Кадровый состав сети</h3>
                        <table className="admin-table">
                            <thead>
                                <tr><th>ID</th><th>Email</th><th>Текущая роль</th><th>Магазин</th><th>Действие</th></tr>
                            </thead>
                            <tbody>
                                {users.map(u => (
                                    <tr key={u.id} className={selectedUserId === u.id ? 'selected-row' : ''}>
                                        <td>{u.id}</td><td>{u.email}</td>
                                        <td><span className={`role-badge ${u.role}`}>{u.role}</span></td>
                                        <td>{u.shopName || "Не назначен"}</td>
                                        <td>
                                            <button className="btn-select" onClick={() => {
                                                setSelectedUserId(u.id); setSelectedRole(u.role); setSelectedShopId(u.shopId || '');
                                            }}>Выбрать</button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>

                    <div className="management-card">
                        <h3>Настройка прав доступа</h3>
                        {selectedUserId ? (
                            <form onSubmit={handleAssign} className="admin-form">
                                <p>Редактирование пользователя ID: <strong>{selectedUserId}</strong></p>
                                <div className="form-group">
                                    <label>Роль в системе</label>
                                    <select value={selectedRole} onChange={e => setSelectedRole(e.target.value)}>
                                        <option value="User">User (Клиент)</option>
                                        <option value="Florist">Florist (Флорист)</option>
                                        <option value="Admin">Admin (Директор)</option>
                                    </select>
                                </div>
                                <div className="form-group">
                                    <label>Привязать к магазину</label>
                                    <select value={selectedShopId} onChange={e => setSelectedShopId(e.target.value)}>
                                        <option value="">Без магазина</option>
                                        {shops.map(s => <option key={s.id} value={s.id}>{s.name}</option>)}
                                    </select>
                                </div>
                                <button type="submit" className="btn-save-rights">Сохранить</button>
                                <button type="button" className="btn-cancel" onClick={() => setSelectedUserId(null)}>Отмена</button>
                            </form>
                        ) : (
                            <p className="placeholder-text">Выберите сотрудника из таблицы для настройки доступа.</p>
                        )}
                    </div>
                </div>
            </div>

            {/* PAYWALL */}
            {isPaywallOpen && (
                <div className="modal-overlay">
                    <div className="modal-content vip-paywall">
                        <h3>👑 Стратегический ИИ-Ассистент Albiflora</h3>
                        <p className="vip-description">Доступно исключительно владельцам сетей в рамках премиум-пакета.</p>
                        <div className="vip-price-tag">10 000 ₽ <span>/ месяц</span></div>
                        <div className="modal-actions">
                            <button type="button" className="btn-cancel" onClick={() => setIsPaywallOpen(false)}>Позже</button>
                            <button type="button" className="btn-upgrade-vip" onClick={() => { alert("Платежный шлюз..."); setIsPaywallOpen(false); }}>Активировать</button>
                        </div>
                    </div>
                </div>
            )}

            {/* ОКНО СОЗДАНИЯ МАГАЗИНА */}
            {isShopModalOpen && (
                <div className="modal-overlay">
                    <div className="modal-content expanded-modal">
                        <h3>🏪 Параметры интеграции новой торговой точки</h3>
                        <form onSubmit={handleCreateShop} className="bouquet-form">
                            <div className="form-group">
                                <label>Название филиала</label>
                                <input type="text" className="form-input" placeholder="Albiflora Центр" value={newShop.name} onChange={e => setNewShop({ ...newShop, name: e.target.value })} required />
                            </div>

                            <div className="form-group">
                                <label>Найдите адрес филиала на карте или кликните мышкой</label>
                                <div className="map-wrapper">
                                    <Map
                                        state={{ center: mapCenter, zoom: 14 }}
                                        width="100%"
                                        height="250px"
                                        onClick={(e) => handleMapClick(e, 'create')}
                                    >
                                        <SearchControl
                                            options={{ noPlacemark: true, placeholder: 'Введите адрес в Ростове...' }}
                                            onLoad={(ref) => { createSearchRef.current = ref; }}
                                            onResultSelect={handleCreateAddressSelect}
                                        />
                                        <Placemark geometry={mapCenter} />
                                    </Map>
                                </div>
                                {newShop.address && (
                                    <div className="selected-address-badge">
                                        📍 Текущий адрес: <strong>{newShop.address}</strong>
                                    </div>
                                )}
                            </div>

                            <div className="form-group checkbox-group">
                                <label className="switch-label">
                                    <input type="checkbox" checked={newShop.isOwned} onChange={e => setNewShop({ ...newShop, isOwned: e.target.checked })} />
                                    Помещение находится в собственности
                                </label>
                            </div>

                            {!newShop.isOwned && (
                                <div className="animate-fade-in">
                                    <div className="form-group"><label>Стоимость аренды (₽)</label><input type="number" className="form-input" placeholder="150000" value={newShop.rentPrice} onChange={e => setNewShop({ ...newShop, rentPrice: e.target.value })} required /></div>
                                    <div className="form-group"><label>Число месяца для оплаты</label><input type="number" min="1" max="31" className="form-input" placeholder="25" value={newShop.rentPaymentDate} onChange={e => setNewShop({ ...newShop, rentPaymentDate: e.target.value })} required /></div>
                                </div>
                            )}
                            <div className="form-group"><label>Фиксированная коммуналка (₽/мес)</label><input type="number" className="form-input" placeholder="12000" value={newShop.utilityBills} onChange={e => setNewShop({ ...newShop, utilityBills: e.target.value })} required /></div>

                            <div className="modal-actions">
                                <button type="button" className="btn-cancel" onClick={() => setIsShopModalOpen(false)}>Отмена</button>
                                <button type="submit" className="btn-save-bouquet">Запустить точку</button>
                            </div>
                        </form>
                    </div>
                </div>
            )}

            {/* ОКНО ПЕРЕЕЗДА ТОЧКИ */}
            {isRelocateModalOpen && shopToRelocate && (
                <div className="modal-overlay">
                    <div className="modal-content expanded-modal">
                        <h3>🚚 Переезд филиала: {shopToRelocate.name}</h3>
                        <form onSubmit={handleRelocateSubmit} className="bouquet-form">
                            <div className="form-group">
                                <label>Укажите новый адрес на карте или кликните мышкой</label>
                                <div className="map-wrapper">
                                    <Map
                                        state={{ center: mapCenter, zoom: 14 }}
                                        width="100%"
                                        height="250px"
                                        onClick={(e) => handleMapClick(e, 'relocate')}
                                    >
                                        <SearchControl
                                            options={{ noPlacemark: true, placeholder: 'Введите новый адрес...' }}
                                            onLoad={(ref) => { relocateSearchRef.current = ref; }}
                                            onResultSelect={handleRelocateAddressSelect}
                                        />
                                        <Placemark geometry={mapCenter} />
                                    </Map>
                                </div>
                                {shopToRelocate.address && (
                                    <div className="selected-address-badge">
                                        📍 Новый адрес: <strong>{shopToRelocate.address}</strong>
                                    </div>
                                )}
                            </div>

                            <div className="form-group checkbox-group"><label className="switch-label"><input type="checkbox" checked={shopToRelocate.isOwned} onChange={e => setShopToRelocate({ ...shopToRelocate, isOwned: e.target.checked })} /> Новое помещение в собственности</label></div>

                            {!shopToRelocate.isOwned && (
                                <div className="animate-fade-in">
                                    <div className="form-group"><label>Новая стоимость аренды (₽)</label><input type="number" className="form-input" value={shopToRelocate.rentPrice || ''} onChange={e => setShopToRelocate({ ...shopToRelocate, rentPrice: e.target.value })} required /></div>
                                    <div className="form-group"><label>Новое число оплаты аренды</label><input type="number" min="1" max="31" className="form-input" value={shopToRelocate.rentPaymentDate || ''} onChange={e => setShopToRelocate({ ...shopToRelocate, rentPaymentDate: e.target.value })} required /></div>
                                </div>
                            )}
                            <div className="form-group"><label>Новая коммуналка (₽/мес)</label><input type="number" className="form-input" value={shopToRelocate.utilityBills || ''} onChange={e => setShopToRelocate({ ...shopToRelocate, utilityBills: e.target.value })} required /></div>

                            <div className="modal-actions">
                                <button type="button" className="btn-cancel" onClick={() => setIsRelocateModalOpen(false)}>Отмена</button>
                                <button type="submit" className="btn-save-bouquet">Подтвердить переезд</button>
                            </div>
                        </form>
                    </div>
                </div>
            )}
        </YMaps>
    );
};

export default AdminPanel;