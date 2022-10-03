import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Book } from './Book';
import { Layout } from '../shared/Layout';

export function Books() {
    const [data, setData] = useState([]);

    useEffect(() => {
        async function fetchData() {
            axios.get('/api/books/get?currentPage=1&pageSize=10')
                .then((res) => {
                    if (res.data.result) {
                        setData(res.data.value);
                    } else {
                        console.log(res.data.errors);
                    }
                })
                .catch(err => {
                    console.log(err.response.data.errors);
                });
        }
        fetchData();
    }, []);

    return (
        <Layout>
            <div>
                <div className="d-flex justify-content-end mb-4">
                    <a href="/books/add" type="button" className="btn btn-outline-success">
                        <i className="fa fa-plus mr-2"></i>
                        Add
                    </a>
                </div>


                <div className="row">
                    {
                        data.map((x, key) => <Book key={key} data={x} />)
                    }
                </div>
            </div>
        </Layout>
    );
}