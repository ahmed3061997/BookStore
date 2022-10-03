import React, { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form';
import { Layout } from '../shared/Layout';

export function AddBook() {

    const [authors, setAuthors] = useState([]);
    const [author, setAuthor] = useState({ name: 'Choose author...', image: '' });
    const { register, handleSubmit, formState: { errors } } = useForm();

    const onSubmit = async (data) => {
        console.log(data);
        var formData = new FormData();
        formData.append('Name', data.Name);
        formData.append('Description', data.Description);
        formData.append('AuthorId', author.id);
        formData.append('CoverImgFile', data.CoverImg[0]);
        var response = await fetch('/api/books/create', {
            method: 'post',
            body: formData
        });
        const res = await response.json();
        if (res.result === true)
            window.location.href = '/';
    }

    useEffect(() => {
        const fetchData = async () => {
            var response = await fetch('/api/authors/get_all');
            const res = await response.json();
            if (res.result) {
                setAuthors(res.value);
            } else {
                console.log(res.errors);
            }
        }
        fetchData();
    }, []);

    return (
        <Layout>
            <div>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <div className="form-group mb-4">
                        <label htmlFor="Name">Name</label>
                        <input type="text" className="form-control" id="Name" name="Name" {...register('Name', { required: true })} placeholder="Name" />
                        {errors.Name && <small className="text-danger">This field is required</small>}
                    </div>
                    <div className="form-group mb-4">
                        <label htmlFor="Description">Description</label>
                        <input type="text" className="form-control" id="Description" name="Description" {...register('Description', { required: true })} placeholder="Description" />
                        {errors.Description && <small className="text-danger">This field is required</small>}
                    </div>
                    <div className="form-group mb-4">
                        <label htmlFor="Author">Author</label>
                        <div className="dropdown author-dropdown">
                            <button className="btn dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false" {...register('Author', { required: author.id == null })}>
                                <img className="dropdown-avatar" src={author.image} />
                                <span>{author.name}</span>
                            </button>
                            <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
                                {
                                    authors.map((x, i) => {
                                        return (
                                            <button key={i} className="dropdown-item" type="button" onClick={() => setAuthor(x)}>
                                                <img className="dropdown-avatar" src={x.image} />
                                                <span>{x.name}</span>
                                            </button>
                                        )
                                    })
                                }
                            </div>
                        </div>
                        {errors.Author && <small className="text-danger">This field is required</small>}
                    </div>
                    <div className="d-flex flex-column mb-4">
                        <label htmlFor="CoverImg">Cover Image</label>
                        <input type="file" className="form-control-file mt-2" id="CoverImg" name="CoverImg" multiple={false} {...register('CoverImg', { required: true })} />
                        {errors.CoverImg && <small className="text-danger">This field is required</small>}
                    </div>
                    <div className="d-flex justify-content-end">
                        <button type="submit" className="btn btn-success mx-3">Save</button>
                        <a href="/" type="button" className="btn btn-outline-danger">Cancel</a>
                    </div>
                </form>
            </div>
        </Layout>
    );
}