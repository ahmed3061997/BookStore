import React from 'react';

export function Layout({ children }) {
    return (
        <div>
            <nav className="navbar navbar-expand-lg navbar-light bg-white">
                <div className="container-fluid">
                    <button
                        className="navbar-toggler"
                        type="button"
                        data-mdb-toggle="collapse"
                        data-mdb-target="#navbarCenteredExample"
                        aria-controls="navbarCenteredExample"
                        aria-expanded="false"
                        aria-label="Toggle navigation"
                    >
                        <i className="fas fa-bars"></i>
                    </button>


                    <div
                        className="collapse navbar-collapse justify-content-center"
                        id="navbarCenteredExample"
                    >
                        <ul className="navbar-nav mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link" href="/">Books</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link" href="/authors">Authors</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div className="container my-4">
                {children}
            </div>
        </div>
    );
}