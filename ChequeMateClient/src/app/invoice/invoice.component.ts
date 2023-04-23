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

  constructor(private invoiceService: InvoiceService, private router: Router) {
  }

  ngOnInit(): void {
    this.loadInvoices();
  }

  loadInvoices = () => {
    this.invoiceService.getInvoices(this.isPaid).subscribe({
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
    if(event.value === 'ShowUnPaid'){
      this.isPaid = false;
      this.loadInvoices();
    }
    else{
      this.isPaid = true;
      this.loadInvoices();
    }
  }

  createNew = () => {
    this.router.navigate(['/create']);
  }
}
