import { Books } from "./components/Books";
import { AddBook } from "./components/AddBook";
import { Authors } from "./components/Authors";
import { AddAuthor } from "./components/AddAuthor";

const AppRoutes = [
    {
        index: true,
        element: <Books />
    },
    {
        path: '/books/add',
        element: <AddBook />
    },
    {
        path: '/authors',
        element: <Authors />
    },
    {
        path: '/authors/add',
        element: <AddAuthor />
    }
];

export default AppRoutes;
