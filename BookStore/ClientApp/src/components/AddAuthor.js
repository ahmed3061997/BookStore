import React from 'react';
import { useForm } from 'react-hook-form';

export function AddAuthor() {

    const { register, handleSubmit, formState: { errors } } = useForm();
    const onSubmit = async (data) => {
        var formData = new FormData();
        formData.append('Name', data.Name);
        formData.append('Category', data.Category);
        formData.append('Img', data.Img[0]);
        var response = await fetch('/api/authors/create', {
            method: 'post',
            body: formData
        });
        const result = await response.json();
        if (result === true)
            window.location.href = '/authors';
    }

    return (

        <div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <div className="form-group">
                    <label htmlFor="Name">Name</label>
                    <input type="text" className="form-control" id="Name" name="Name" {...register('Name', { required: true })} placeholder="Name" />
                    {errors.Name && <small className="text-danger">This field is required</small>}
                </div>
                <div className="form-group">
                    <label htmlFor="Category">Category</label>
                    <input type="text" className="form-control" id="Category" name="Category" {...register('Category', { required: true })} placeholder="Category" />
                    {errors.Category && <small className="text-danger">This field is required</small>}
                </div>
                <div className="form-group">
                    <label htmlFor="Img">Profile Image</label>
                    <input type="file" className="form-control-file" id="Img" name="Img" multiple={false} {...register('Img', { required: true })} />
                    {errors.Img && <small className="text-danger">This field is required</small>}
                </div>
                <div className="d-flex justify-content-end">
                    <button type="submit" className="btn btn-success mx-3">Save</button>
                    <button type="button" className="btn btn-outline-danger">Cancel</button>
                </div>
            </form>
        </div>
    );
}