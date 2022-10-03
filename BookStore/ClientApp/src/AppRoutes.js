import { Books } from "./components/book/Books";
import { AddBook } from "./components/book/AddBook";
import { Authors } from "./components/author/Authors";
import { AddAuthor } from "./components/author/AddAuthor";
import { Register } from "./components/account/Register";
import { Login } from "./components/account/Login";
import { ProtectedRoute } from "./ProtectedRoute";

const AppRoutes = [
    {
        index: true,
        element:
            <ProtectedRoute>
                <Books />
            </ProtectedRoute>
    },
    {
        path: '/register',
        element: <Register />
    },
    {
        path: '/login',
        element: <Login />
    },
    {
        path: '/books/index',
        element:
            <ProtectedRoute>
                <Books />
            </ProtectedRoute>
    },
    {
        path: '/books/add',
        element:
            <ProtectedRoute>
                <AddBook />
            </ProtectedRoute>
    },
    {
        path: '/authors',
        element:
            <ProtectedRoute>
                <Authors />
            </ProtectedRoute>
    },
    {
        path: '/authors/add',
        element:
            <ProtectedRoute>
                <AddAuthor />
            </ProtectedRoute>
    }
];

export default AppRoutes;
