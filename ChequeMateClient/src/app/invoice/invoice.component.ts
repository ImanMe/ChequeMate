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

  constructor(private invoiceService: InvoiceService, private router: Router) {
  }

  ngOnInit(): void {
    this.loadInvoices();
  }

  loadInvoices = (isPaid: boolean = false) => {
    this.invoiceService.getInvoices(isPaid).subscribe({
      next: (result) => {
        this.invoiceListResult = result,
          this.invoices = this.invoiceListResult.invoices
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  filterDataByPaymentStatus = (event: any) => {
    this.loadInvoices(event.value === 'ShowPaid');
  }

  createNew = () => {
    this.router.navigate(['/create']);
  }
}
