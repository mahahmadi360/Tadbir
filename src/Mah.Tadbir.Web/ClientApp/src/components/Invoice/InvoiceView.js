import React, { Component } from 'react';
import { InvoiceStuffPriceService } from '../../service/invoiceStuffPriceService';
import { InvoicePriceService } from '../../service/invoicePriceService';

export class InvoiceView extends Component {
    constructor(props) {
        super(props);
        this.state = { invoice: null, loading: true };
    }

    componentDidMount() {
        this.populateInvoiceData(this.props.match.params.id);
    }

    renderInvoiceStuff(invoiceStuff, index) {
        let invoiceStuffPriceService = new InvoiceStuffPriceService(
            invoiceStuff
        );
        return (
            <tr key={invoiceStuff.id}>
                <td>{index}</td>
                <td className='td-150'>{invoiceStuff.stuffName}</td>
                <td >{invoiceStuff.stuffQuantity}</td>
                <td className='td-100'>{invoiceStuff.stuffPrice}</td>
                <td className='td-100'>{invoiceStuff.offPercent}</td>
                <td className='td-100'>{invoiceStuffPriceService.unitPriceAfterOff} </td>
                <td className='td-100'>{invoiceStuffPriceService.totalPrice}</td>
                <td className='td-100'>{invoiceStuffPriceService.totalPriceAfterOff}</td>
                <td className='td-100'>{invoiceStuffPriceService.benefitPerUnit}</td>
                <td className='td-100'>{invoiceStuffPriceService.benefitPerTotal}</td>
            </tr>
        );
    }

    renderInvoiceTotoal(invoice) {
        let invoicePriceService = new InvoicePriceService(invoice);
        return (
            <>
                <tr>
                    <td colSpan={8} rowSpan={3}>
                        توضیحات: {invoice.description}
                    </td>
                    <td>جمع کل</td>
                    <td>{invoicePriceService.totalPrice}</td>
                </tr>
                <tr>
                    <td>جمع تخفیفات</td>
                    <td>{invoicePriceService.totalBenefit}</td>
                </tr>
                <tr>
                    <td>قابل پرداخت </td>
                    <td>{invoicePriceService.totalPriceAfterOff}</td>
                </tr>
            </>
        );
    }
    renderInvoiceViewer(invoice) {
        return (
            <table className="border-table">
                <tbody>
                    <tr>
                        <td colSpan={8} rowSpan="2">
                            نام خریدار: {invoice.customerName}
                        </td>
                        <td colSpan={2}>تاریخ ثبت: {invoice.registerDate}</td>
                    </tr>
                    <tr>
                        <td colSpan={2}>شماره فاکتور: {invoice.id}</td>
                    </tr>
                    <tr>
                        <td>ردیف</td>
                        <td>عنوان</td>
                        <td>تعداد</td>
                        <td>قیمت واحد بدون تخفیف</td>
                        <td>درصد تخفیف</td>
                        <td> قیمت واحد با تخفیف</td>
                        <td>سرجمع بدون تخفیف</td>
                        <td>سرجمع با تخفیف</td>
                        <td>سود مشتری از تخفیف واحد</td>
                        <td>سود مشتری از تخفیف کل</td>
                    </tr>

                    {invoice.invoiceStuffs.map(this.renderInvoiceStuff)}
                    {this.renderInvoiceTotoal(invoice)}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading ? (
            <p>
                <em>در حال دریافت...</em>
            </p>
        ) : (
            this.renderInvoiceViewer(this.state.invoice)
        );

        return (
            <div>
                <h1 id="tabelLabel">
                    فاکتور شماره {this.props.match.params.id}
                </h1>
                {contents}
            </div>
        );
    }

    async populateInvoiceData(id) {
        this.setState({ loading: true });
        const response = await fetch(`api/Invoice/${id}`);
        const data = await response.json();

        const stuffs = await fetch(`api/stuff`);
        const stuffList = await stuffs.json();

        data.invoiceStuffs.map(
            (invoiceStuff) =>
                (invoiceStuff.stuffName = stuffList.find(
                    (stuff) => stuff.id == invoiceStuff.stuffId
                ).name)
        );
        this.setState({ invoice: data, loading: false });
    }
}
