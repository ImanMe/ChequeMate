import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IInvoice, IInvoiceListResult } from '../models/ListItem';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(private http: HttpClient) { }

  getInvoices = (isPaid: boolean = false): Observable<IInvoiceListResult> => {
    const url = isPaid ? `/api/invoices?isPaid=${isPaid}` : '/api/invoices';
    return this.http.get<IInvoiceListResult>(url);
  }

  getInvoice = (id: number): Observable<IInvoice> => this.http.get<IInvoice>(`api/invoices/${id}`);

  markAsPaid = (invoiceId: number) => {
    const url = `${'/api/invoices'}/${invoiceId}/mark-as-paid`;
    return this.http.patch(url, null);
  }
}
