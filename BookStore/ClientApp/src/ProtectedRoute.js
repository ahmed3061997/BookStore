import React from 'react';
import { Navigate } from 'react-router';

export const ProtectedRoute = ({ children }) => {
    var token = localStorage.getItem('access-token');
    if (!token) {
        return <Navigate to="/login" replace />;
    }
    return children;
};