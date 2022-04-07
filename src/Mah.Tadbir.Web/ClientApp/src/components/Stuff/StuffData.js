import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class StuffData extends Component {
    static displayName = StuffData.name;

    constructor(props) {
        super(props);
        this.state = { stuffs: [], loading: true };
        this.deleteRecord = this.deleteRecord.bind(this);
    }

    componentDidMount() {
        this.populateStuffData();
    }

    renderStuffTable(stuffs) {
        return (
            <div>
                <button className="btn btn-success">
                                    <Link
                                        to={{
                                            pathname: `/stuffs/create`,
                                        }}
                                    >
                                        ایجاد
                                    </Link>
                                </button>
            <table className="table table-striped" aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>نام کالا</th>
                        <th>قیمت کالا</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {stuffs.map((stuff) => (
                        <tr key={stuff.id}>
                            <td>{stuff.name}</td>
                            <td>{stuff.price}</td>
                            <td>
                                <button className="btn btn-primary">
                                    <Link
                                        to={{
                                            pathname: `/stuffs/Edit/${stuff.id}`,
                                        }}
                                    >
                                        ویرایش
                                    </Link>
                                </button>

                                <button
                                    className="btn btn-danger"
                                    onClick={() => this.deleteRecord(stuff.id)}
                                >
                                    حذف
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>در حال دریافت...</em>
            </p>
        ) : (
            this.renderStuffTable(this.state.stuffs)
        );

        return (
            <div>
                <h1 id="tabelLabel">لیست کالا</h1>
                {contents}
            </div>
        );
    }

    async populateStuffData() {
        this.setState({ loading: true });
        const response = await fetch('api/stuff');
        const data = await response.json();
        this.setState({ stuffs: data, loading: false });
    }

    async deleteRecord(id) {
        await fetch(`api/stuff/${id}`, { method: 'DELETE' });
        await this.populateStuffData();
    }
}
