import { InvoiceStuffPriceService } from './invoiceStuffPriceService';
export class InvoicePriceService {
    constructor(invoice) {
        this.invoice = invoice;
        
    }

    get totalPrice() {
        return this.getSumOf((a) => {
            return new InvoiceStuffPriceService(a).totalPrice;
        });
    }

    //final payment
    get totalPriceAfterOff() {
        return this.getSumOf((a) => {
            return new InvoiceStuffPriceService(a).totalPriceAfterOff;
        });
    }

    get totalBenefit() {
        return this.getSumOf((a) => {
            return new InvoiceStuffPriceService(a).benefitPerTotal;
        });
    }

    getSumOf(memberHandler) {
        // with initial value to avoid when the array is empty
        return this.invoice.invoiceStuffs
            .map(memberHandler)
            .reduce((a, b) => a + b, 0);
    }
}
