import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const ProtectedRoute = ({ children, allowedRoles }) => {
    const { user } = useAuth();

    // 1. Если не залогинен — на вход
    if (!user) return <Navigate to="/login" replace />;

    // 2. Если роли не совпадают — на витрину
    // Добавляем проверку: если allowedRoles передан, проверяем вхождение в него роли юзера
    if (allowedRoles && !allowedRoles.includes(user.role)) {
        console.warn(`Доступ запрещен для роли: ${user.role}`);
        return <Navigate to="/showcase" replace />;
    }

    return children;
};

export default ProtectedRoute;
