import { InvoiceEditor } from './InvoiceEditor';

import React, { Component } from 'react';

export class InvoiceInsert extends Component {
    constructor(props) {
        super(props);
        this.state = { invoice: {invoiceStuffs:[]} };
    }

    renderInvoiceEditor(invoice) {
        return (
            <InvoiceEditor
                invoice={invoice}
                submitHandler={this.sendData}
            ></InvoiceEditor>
        );
    }

    sendData(invoice) {
        return fetch(`api/Invoice`, {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(invoice),
        });
    }

    render() {
        let contents = this.renderInvoiceEditor(this.state.invoice);

        return (
            <div>
                <h1 id="tabelLabel">ایجاد فاکتور</h1>
                {contents}
            </div>
        );
    }
}
