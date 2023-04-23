export interface IInvoiceListResult {
    totalAmountOfUnpaidInvoices: number;
    averageTimeOfPaymentInHours: number;
    invoices:                    IInvoice[];
}

export interface IInvoice {
    id:           number;
    invoiceDate:  string;
    customerName: string;
    dueDate:      string;
    paymentDate:  null | string;
    isPaid:       boolean;
    totalAmount:  number;
    listItems:    IListItem[];
}

export interface IListItem {
    description: string;
    quantity:    number;
    totalPrice:  number;
}

export interface ICreateInvoice{
    customerName: string;
    dueDate:      string;
    listItems:IListItem[];
}