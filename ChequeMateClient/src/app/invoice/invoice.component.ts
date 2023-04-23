import { Component, OnInit } from '@angular/core';
import { InvoiceService } from '../Services/invoice.service';
import { IInvoice, IInvoiceListResult } from '../models/ListItem';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {
  title = 'ChequeMateClient';
  panelOpenState = true;
  invoiceListResult: IInvoiceListResult;
  invoices: IInvoice[];
  isPaid = true;
  allInvoices: IInvoice[];
  unpaidInvoices: IInvoice[];
  constructor(private invoiceService: InvoiceService, private router: Router) {
  }

  ngOnInit(): void {
    this.loadInvoices();
  }

  loadInvoices = () => {
    this.invoiceService.getInvoices(this.isPaid).subscribe({
      next: (result) => {
        this.invoiceListResult = result;
        this.invoices = this.invoiceListResult.invoices;
        if (this.isPaid === false)
          this.unpaidInvoices = this.invoices;
        else this.allInvoices = this.invoices;
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  filterDataByPaymentStatus = (event: any) => {
    if (event.value === 'ShowUnPaid') {
      this.isPaid = false;
      if (this.unpaidInvoices && this.unpaidInvoices.length > 0) {
        this.invoices = this.unpaidInvoices;
        console.log(this.unpaidInvoices)
      }
      else {
        this.loadInvoices();
      }
    }
    else {
      this.isPaid = true;
      if (this.allInvoices && this.allInvoices.length > 0) {
        this.invoices = this.allInvoices;
      }
      else {
        this.loadInvoices();
      }
    }
  }

  createNew = () => {
    this.router.navigate(['/create']);
  }
}
