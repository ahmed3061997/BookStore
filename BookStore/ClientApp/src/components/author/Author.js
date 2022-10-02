import React from 'react';

export function Author({ data }) {
    return (
        <div className="col-lg-3 col-md-6 mb-4 mb-lg-0">
            <div className="card shadow-sm border-0 rounded card-has-bg">
                <div className="card-img-overlay">
                    <div className="d-flex justify-content-end mb-2">
                        <a className="mx-3" type="button" data-toggle="tooltip" data-placement="top" title="Delete">
                            <i className="fa fa-trash-can text-danger"></i>
                        </a>
                        <a type="button" data-toggle="tooltip" data-placement="top" title="Edit">
                            <i className="fa fa-pen-to-square text-warning"></i>
                        </a>
                    </div>
                    <div className="card-body p-0">
                        <img src={data.image} alt="" className="w-100 card-img-top" />
                        <div className="p-4">
                            <h5 className="mb-0">{data.name}</h5>
                            <p className="small text-muted">{data.category}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}