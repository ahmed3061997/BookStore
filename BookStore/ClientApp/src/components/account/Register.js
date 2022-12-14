import React, { useState } from 'react';
import api from '../../api';
import { useForm } from 'react-hook-form';
import { FallingLines } from 'react-loader-spinner'

export function Register() {
    const { register, handleSubmit, formState } = useForm();
    const [errors, setErrors] = useState([]);
    const [loading, setLoading] = useState(false);
    const onSubmit = (data) => {
        setErrors([]);
        setLoading(true);
        api.post('/account/register', data)
            .then((res) => {
                setLoading(false);
                if (res.data.result === true) {
                    localStorage.setItem('access-token', res.data.value.token);
                    window.location.href = '/';
                } else {
                    setErrors(res.data.errors);
                }
            })
            .catch(err => {
                var errors = err.response.data.errors;
                setErrors(errors);
                setLoading(false);
            });
    }

    return (
        <div className="container h-100 my-4">
            {loading &&
                <div className="overlay">
                    <FallingLines
                        color="#0d6efd"
                        width="100"
                        visible={true}
                        ariaLabel='falling-lines-loading'
                    />
                </div>
            }
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

                                    <p className="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign up</p>

                                    <form className="mx-1 mx-md-4" onSubmit={handleSubmit(onSubmit)}>

                                        {errors.length > 0 &&
                                            <div className="alert alert-danger" role="alert">
                                                <ul className="m-0">
                                                    {
                                                        errors.map((x, key) => <li key={key}>{x}</li>)
                                                    }
                                                </ul>
                                            </div>
                                        }

                                        <div className="d-flex flex-row align-items-center mb-2">
                                            <i className="fa fa-envelope fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="FirstName">First Name</label>
                                                <input type="text" className="form-control" id="FirstName" name="FirstName" {...register('FirstName', { required: true })} placeholder="First Name" />
                                                {formState.errors.FirstName && <small className="text-danger">This field is required</small>}
                                            </div>
                                        </div>

                                        <div className="d-flex flex-row align-items-center mb-2">
                                            <i className="fa fa-envelope fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="LastName">Last Name</label>
                                                <input type="text" className="form-control" id="LastName" name="LastName" {...register('LastName', { required: true })} placeholder="Last Name" />
                                                {formState.errors.LastName && <small className="text-danger">This field is required</small>}
                                            </div>
                                        </div>

                                        <div className="d-flex flex-row align-items-center mb-2">
                                            <i className="fa fa-envelope fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="Email">Email</label>
                                                <input type="email" className="form-control" id="Email" name="Email" {...register('Email', { required: true })} placeholder="Email" />
                                                {formState.errors.Email && <small className="text-danger">This field is required</small>}
                                            </div>
                                        </div>

                                        <div className="d-flex flex-row align-items-center mb-2">
                                            <i className="fa fa-lock fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="Password">Password</label>
                                                <input type="password" className="form-control" id="Password" name="Password" {...register('Password', { required: true })} placeholder="Password" />
                                                {formState.errors.Password && <small className="text-danger">This field is required</small>}
                                            </div>
                                        </div>

                                        <div className="d-flex flex-row align-items-center mb-4">
                                            <i className="fa fa-key fa-lg me-3 fa-fw"></i>
                                            <div className="form-outline flex-fill mb-0">
                                                <label className="form-label" htmlFor="ConfirmPassword">Repeat your password</label>
                                                <input type="password" className="form-control" id="ConfirmPassword" name="ConfirmPassword" {...register('ConfirmPassword', { required: true })} placeholder="Confirm Password" />
                                                {formState.errors.ConfirmPassword && <small className="text-danger">This field is required</small>}
                                            </div>
                                        </div>

                                        <div className="d-flex justify-content-center mx-4 mb-3 mb-lg-4">
                                            <button type="submit" className="btn btn-primary btn-lg">Register</button>
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