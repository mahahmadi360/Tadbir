export class InvoiceStuffPriceService {
    constructor(invoiceStuff) {
        this.invoiceStuff = invoiceStuff;
    }

    get unitPriceAfterOff() { 
        return (this.invoiceStuff.stuffPrice * (100 - this.invoiceStuff.offPercent) / 100);
    }

    get totalPrice() { 
        return (this.invoiceStuff.stuffPrice * this.invoiceStuff.stuffQuantity);
    }

    get totalPriceAfterOff() { 
        return (this.unitPriceAfterOff * this.invoiceStuff.stuffQuantity);
    }

    get benefitPerUnit(){
        return (this.invoiceStuff.stuffPrice - this.unitPriceAfterOff);
    }

    get benefitPerTotal(){
        return this.totalPrice - this.totalPriceAfterOff  ;
    }
}
