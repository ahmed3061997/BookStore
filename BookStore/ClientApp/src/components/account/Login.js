﻿import React from 'react';

export function Login() {
    return (
        <div className="container h-100 my-4">
            <div className="row d-flex justify-content-center align-items-center h-100">
                <div className="col-lg-12 col-xl-11">
                    <div className="card text-black" style={{ borderRadius: '25px' }}>
                        <div className="card-body">
                            <div className="row justify-content-center">

                                <div className="col-md-10 col-lg-6 col-xl-7 d-flex align-items-center order-2 order-lg-1">
                                    <img src={require('../../assets/imgs/draw1.webp')}
                                        className="img-fluid" alt="Sample image" />
                                </div>

                                <div className="col-md-10 col-lg-6 col-xl-5 order-1 order-lg-2">

                                    <p className="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign In</p>

                                    <form className="mx-1 mx-md-4">

                                        <div className="d-flex flex-row align-items-center mb-2">
                                            <i className="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="form3Example3c">Your Email</label>
                                                <input type="email" id="form3Example3c" className="form-control" />
                                            </div>
                                        </div>

                                        <div className="d-flex flex-row align-items-center mb-2">
                                            <i className="fas fa-lock fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="form3Example4c">Password</label>
                                                <input type="password" id="form3Example4c" className="form-control" />
                                            </div>
                                        </div>

                                        <div className="form-check d-flex justify-content-center mb-5">
                                            <input className="form-check-input me-2" type="checkbox" value="" id="RememberMe" />
                                            <label className="form-check-label" htmlFor="RememberMe">
                                                Remember Me!
                                            </label>
                                        </div>

                                        <div className="d-flex justify-content-center mb-5">
                                            <span>Didn't have account yet ? <a href="/register">Create an account</a></span>
                                        </div>

                                        <div className="d-flex justify-content-center mx-4 mb-3 mb-lg-4">
                                            <button type="submit" className="btn btn-primary btn-lg">Sign In</button>
                                        </div>

                                    </form>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}