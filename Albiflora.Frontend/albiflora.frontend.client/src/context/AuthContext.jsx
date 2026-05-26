import React, { createContext, useState, useContext } from 'react';

const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(() => {
        const token = localStorage.getItem('token');
        const role = localStorage.getItem('userRole');
        return (token && role) ? { token, role } : null;
    });

    const login = (token, role, shopId) => {
        localStorage.setItem('token', token);
        localStorage.setItem('userRole', role);
        localStorage.setItem('shopId', shopId); // Ñîõðàíÿåì "ñâîé" ìàãàçèí
        setUser({ token, role, shopId });
    };

    const logout = () => {
        localStorage.clear();
        setUser(null);
    };

    return (
        <AuthContext.Provider value={{ user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

// ÂÎÒ ÝÒÀ ÑÒÐÎ×ÊÀ — ÃËÀÂÍÛÉ ÂÈÍÎÂÍÈÊ ÁÅËÎÃÎ ÝÊÐÀÍÀ
export const useAuth = () => useContext(AuthContext); 