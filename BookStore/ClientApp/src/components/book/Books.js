import React, { useEffect, useState } from 'react';
import { Book } from './Book';

export function Books() {
    const [data, setData] = useState([]);

    useEffect(() => {
        async function fetchData() {
            var response = await fetch('/api/books/get?currentPage=1&pageSize=10');
            const res = await response.json();
            if (res.result) {
                setData(res.value);
            } else {
                console.log(res.errors);
            }
        }
        fetchData();
    }, []);

    return (

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
    );
}