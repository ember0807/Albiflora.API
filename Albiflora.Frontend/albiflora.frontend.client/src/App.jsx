import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LandingPage from './pages/LandingPage';
import LoginPage from './pages/LoginPage';
import FloristPage from './pages/FloristPage';
import ShowcasePage from './pages/ShowcasePage';
import { AuthProvider } from './context/AuthContext';
import ProtectedRoute from './components/ProtectedRoute';
import RegisterPage from './pages/RegisterPage';
import AdminPanel from './pages/AdminPanel';

function App() {
    return (
        <AuthProvider>
            <Router>
                <Routes>
                    <Route path="/" element={<LandingPage />} />
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/register" element={<RegisterPage />} /> 

                    {/* Приватный роут для админа */}
                    <Route path="/florist" element={
                        <ProtectedRoute allowedRoles={['Admin', 'Florist']}>
                            <FloristPage />
                        </ProtectedRoute>
                    } />
                    {/* Панель директора — только для роли Admin */}
                    <Route path="/admin" element={
                        <ProtectedRoute allowedRoles={['Admin']}>
                            <AdminPanel />
                        </ProtectedRoute>
                    } />


                    {/* Витрина доступна всем, но кнопка "Назад" в ней будет зависеть от контекста */}
                    <Route path="/showcase" element={<ShowcasePage />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
}


export default App;