import React, { useEffect, useState } from 'react';
import { Layout } from '../shared/Layout';
import { Author } from './Author';

export function Authors() {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            var response = await fetch('/api/authors/get?currentPage=1&pageSize=10');
            const res = await response.json();
            if (res.result) {
                setData(res.value);
            }
        }
        fetchData();
    }, []);

    return (
        <Layout>
            <div>
                <div className="d-flex justify-content-end mb-4">
                    <a href="/authors/add" type="button" className="btn btn-outline-success">
                        <i className="fa fa-plus mr-2"></i>
                        Add
                    </a>
                </div>

                <div className="row pb-5 mb-4">
                    {
                        data.map((x, key) => <Author key={key} data={x} />)
                    }
                </div>
            </div>
        </Layout>
    );
}