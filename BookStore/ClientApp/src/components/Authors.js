import React, { useEffect, useState } from 'react';
import { Author } from './Author';

export function Authors() {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            var response = await fetch('/api/authors/get?page=1&size=10');
            const result = await response.json();
            setData(result);
        }
        fetchData();
    }, []);

    return (

        <div>
            <div className="d-flex justify-content-end mb-4">
                <a href="/authors/add" type="button" className="btn btn-outline-success">
                    <i className="fa fa-plus mr-2"></i>
                    Add
                </a>
            </div>

            <div className="row pb-5 mb-4">
                {
                    data.map((x, i) => <Author key={i} data={x} />)
                }
            </div>
        </div>
    );
}