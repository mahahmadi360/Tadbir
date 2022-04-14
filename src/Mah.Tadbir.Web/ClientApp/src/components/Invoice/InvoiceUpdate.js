import { InvoiceEditor } from './InvoiceEditor';

import React, { Component } from 'react';

export class InvoiceUpdate extends Component {

    constructor(props) {
        super(props);
        this.state = { invoice: null, loading: true };
    }

    componentDidMount() {
        this.populateInvoiceData( this.props.match.params.id);
    }

    renderInvoiceEditor(invoice) {
        return (
            <InvoiceEditor invoice={invoice} submitHandler={this.sendData}></InvoiceEditor>
        );
    }

    sendData(invoice){
        return fetch(`api/Invoice`, { method: 'put' ,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(invoice)});
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>در حال دریافت...</em>
            </p>
        ) : (
            this.renderInvoiceEditor(this.state.invoice)
        );

        return (
            <div>
                <h1 id="tabelLabel">ویرایش فاکتور</h1>
                {contents}
            </div>
        );
    }

    async populateInvoiceData(id) {
        const response = await fetch(`api/Invoice/${id}`);
        const data = await response.json();
        this.setState({ invoice: data, loading: false });
    }
}