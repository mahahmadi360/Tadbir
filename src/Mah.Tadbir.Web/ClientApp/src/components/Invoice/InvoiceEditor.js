import React, { Component } from 'react';
import { Link, Redirect } from 'react-router-dom';
import { InvoiceStuffPriceService } from '../../service/invoiceStuffPriceService';
import { InvoicePriceService } from '../../service/invoicePriceService';
import Select from 'react-select';

export class InvoiceEditor extends Component {
    constructor(props) {
        super(props);
        var { invoice, submitHandler } = props;
        this.state = { invoice, stuffData: {} };
        this.submitHandler = submitHandler;

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.renderInvoiceStuff = this.renderInvoiceStuff.bind(this);
        this.addRecord = this.addRecord.bind(this);
    }

    componentDidMount() {
        this.populateStuffData();
    }

    async populateStuffData() {
        const response = await fetch(`api/stuff`);
        const data = await response.json();
        this.setState({
            stuffData: data.map((a) => {
                return { label: a.name, value: a.id, price: a.price };
            }),
            stuffDataLoaded: true,
        });
    }

    handleInputChange(event) {
        const target = event.target;
        const value =
            target.type === 'checkbox'
                ? target.checked
                : target.type === 'number'
                ? Number(target.value)
                : target.value;
        const name = target.name;

        this.state.invoice[name] = value;
        this.setState(this.state);
    }

    handleStuffInputChange(event, invoiceStuff) {
        const target = event.target;
        const value =
            target.type === 'checkbox'
                ? target.checked
                : target.type === 'number'
                ? Number(target.value)
                : target.value;
        const name = target.name;
        invoiceStuff[name] = value;

        this.setState(this.state);
    }

    showError() {
        alert('خطا در ذخیره اطلاعات');
    }

    handleSubmit(event) {
        this.submitHandler(this.state.invoice)
            .then((e) => {
                if (e.ok) this.setState({ successed: true });
                else this.showError();
            })
            .catch(this.showError);
    }

    onStuffChange(event, invoiceStuff) {
        invoiceStuff.stuffId = event.value;
        invoiceStuff.stuffName = event.label;
        invoiceStuff.stuffPrice = event.price;
        this.setState(this.state);
    }
    renderStuffSelect(invoiceStuff) {
        let stuffData = [
            { value: invoiceStuff.stuffId, label: invoiceStuff.stuffName },
        ];
        if (this.state.stuffDataLoaded) stuffData = this.state.stuffData;

        return (
            <Select
                options={stuffData}
                placeholder="انتخاب کالا"
                value={stuffData.find((a) => a.value == invoiceStuff.stuffId)}
                onChange={(event) => this.onStuffChange(event, invoiceStuff)}
            />
        );
    }

    renderInvoiceStuff(invoiceStuff, index) {
        let invoiceStuffPriceService = new InvoiceStuffPriceService(
            invoiceStuff
        );
        return (
            <tr key={invoiceStuff.id}>
                <td>{index}</td>
                <td className="td-250">
                    {this.renderStuffSelect(invoiceStuff)}
                </td>
                <td>
                    <input
                        className="percent-input"
                        type="number"
                        name="stuffQuantity"
                        value={invoiceStuff.stuffQuantity}
                        onChange={(event) => {
                            this.handleStuffInputChange(event, invoiceStuff);
                        }}
                    />
                </td>
                <td className="td-100">
                    <input
                        type="number"
                        name="stuffPrice"
                        value={invoiceStuff.stuffPrice}
                        onChange={(event) => {
                            this.handleStuffInputChange(event, invoiceStuff);
                        }}
                    />
                </td>
                <td className="td-100">
                    <input
                        className="percent-input"
                        type="number"
                        name="offPercent"
                        value={invoiceStuff.offPercent}
                        onChange={(event) => {
                            this.handleStuffInputChange(event, invoiceStuff);
                        }}
                    />
                </td>
                <td className="td-100">
                    {invoiceStuffPriceService.unitPriceAfterOff.toFixed(3)}{' '}
                </td>
                <td className="td-100">
                    {invoiceStuffPriceService.totalPrice.toFixed(3)}
                </td>
                <td className="td-100">
                    {invoiceStuffPriceService.totalPriceAfterOff.toFixed(3)}
                </td>
                <td className="td-100">
                    {invoiceStuffPriceService.benefitPerUnit.toFixed(3)}
                </td>
                <td className="td-100">
                    {invoiceStuffPriceService.benefitPerTotal.toFixed(3)}
                </td>
                <td>
                    <span
                        className="btn btn-danger"
                        onClick={() => {
                            this.removeStuff(invoiceStuff);
                        }}
                    >
                        حذف
                    </span>
                </td>
            </tr>
        );
    }

    removeStuff(invoiceStuff) {
        let indexOf = this.state.invoice.invoiceStuffs.indexOf(invoiceStuff);
        this.state.invoice.invoiceStuffs.splice(indexOf, 1);
        this.setState(this.state);
    }

    addRecord() {
        let invoice = this.state.invoice;
        invoice.invoiceStuffs.push({
            id: 0,
            stuffPrice: 0,
            offPercent: 0,
            stuffQuantity: 0,
        });
        this.setState(this.state);
    }

    renderInvoiceTotoal(invoice) {
        let invoicePriceService = new InvoicePriceService(invoice);
        return (
            <>
                <tr>
                    <td colSpan={8} rowSpan={3}>
                        توضیحات:{' '}
                        <input
                            type="text"
                            className="rich-text"
                            name="description"
                            value={invoice.description}
                            onChange={this.handleInputChange}
                        />
                    </td>
                    <td>جمع کل</td>
                    <td colSpan={1}>
                        {invoicePriceService.totalPrice.toFixed(3)}
                    </td>
                    <td>
                        <span
                            className="btn btn-success"
                            onClick={this.addRecord}
                        >
                            اضافه
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>جمع تخفیفات</td>
                    <td colSpan={2}>
                        {invoicePriceService.totalBenefit.toFixed(3)}
                    </td>
                </tr>
                <tr>
                    <td>قابل پرداخت </td>
                    <td colSpan={2}>
                        {invoicePriceService.totalPriceAfterOff.toFixed(3)}
                    </td>
                </tr>
            </>
        );
    }

    render() {
        if (this.state.successed) {
            return <Redirect to="/stuffs" />;
        } else {
            let invoice = this.state.invoice;
            return (
                <>
                    <table className="border-table">
                        <tbody>
                            <tr>
                                <td colSpan={8} rowSpan="2">
                                    نام خریدار:{' '}
                                    <input
                                        type="text"
                                        name="customerName"
                                        value={invoice.customerName}
                                        onChange={this.handleInputChange}
                                    ></input>
                                </td>
                                <td colSpan={3}>
                                    تاریخ ثبت: {invoice.registerDate}
                                </td>
                            </tr>
                            <tr>
                                <td colSpan={3}>شماره فاکتور: {invoice.id}</td>
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
                                <td></td>
                            </tr>

                            {invoice.invoiceStuffs.map(this.renderInvoiceStuff)}
                            {this.renderInvoiceTotoal(invoice)}
                        </tbody>
                    </table>
                    <div>
                        <span className="btn btn-success" onClick={this.handleSubmit}>ثبت</span>
                        <Link className="btn btn-danger"to={{ pathname: `/invoices` }}>انصراف</Link>
                    </div>
                </>
            );
        }
    }
}
