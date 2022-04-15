import React, { Component } from 'react';
import { Link } from 'react-router-dom';

export class InvoiceList extends Component {
    constructor(props) {
        super(props);
        this.state = { invoices: [], loading: true };
        this.deleteRecord = this.deleteRecord.bind(this);
    }

    componentDidMount() {
        this.populateInvoiceData();
    }

    renderInvoiceTable(Invoices) {
        return (
            <div>
                <button className="btn btn-success">
                    <Link
                        to={{
                            pathname: `/Invoices/create`,
                        }}
                    >
                        ایجاد
                    </Link>
                </button>
                <table
                    className="table table-striped"
                    aria-labelledby="tabelLabel"
                >
                    <thead>
                        <tr>
                            <th>شماره فاکتور</th>
                            <th>نام خریدار</th>
                            <th>تاریخ ثبت</th>
                            <th>تعداد اقلام</th>
                            <th>جمع کل</th>
                            <th>جمع تخفیف</th>
                            <th>قابل پرداخت</th>
                            <th>توضیحات</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {Invoices.map((Invoice) => {
                            let defults = {
                                stuffCount: 0,
                                totalOff: 0,
                                totalPrice: 0,
                            };
                            Invoice = Object.assign(defults, Invoice);
                            return (
                                <tr key={Invoice.id}>
                                    <td>{Invoice.id}</td>
                                    <td>{Invoice.customerName}</td>
                                    <td>{Invoice.registerDate}</td>
                                    <td>{Invoice.stuffCount}</td>
                                    <td>{Invoice.totalPrice}</td>
                                    <td>{Invoice.benefitPrice}</td>
                                    <td>
                                        {Invoice.totalPrice -
                                            Invoice.benefitPrice}
                                    </td>
                                    <td>
                                        <span title={Invoice.description}>
                                            ...
                                        </span>
                                    </td>
                                    <td>
                                        <button className="btn btn-primary">
                                            <Link
                                                to={{
                                                    pathname: `/Invoices/View/${Invoice.id}`,
                                                }}
                                            >
                                                مشاهده
                                            </Link>
                                        </button>
                                        <button className="btn btn-primary">
                                            <Link
                                                to={{
                                                    pathname: `/Invoices/Edit/${Invoice.id}`,
                                                }}
                                            >
                                                ویرایش
                                            </Link>
                                        </button>

                                        <button
                                            className="btn btn-danger"
                                            onClick={() =>
                                                this.deleteRecord(Invoice.id)
                                            }
                                        >
                                            حذف
                                        </button>
                                    </td>
                                </tr>
                            );
                        })}
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
            this.renderInvoiceTable(this.state.Invoices)
        );

        return (
            <div>
                <h1 id="tabelLabel">لیست فاکتور ها</h1>
                {contents}
            </div>
        );
    }

    async populateInvoiceData() {
        this.setState({ loading: true });
        const response = await fetch('api/Invoice/info');
        const data = await response.json();
        this.setState({ Invoices: data, loading: false });
    }

    async deleteRecord(id) {
        await fetch(`api/Invoice/${id}`, { method: 'DELETE' });
        await this.populateInvoiceData();
    }
}
