import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { InvoiceService } from 'src/app/Services/invoice.service';
import { IInvoice } from 'src/app/models/ListItem';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html',
  styleUrls: ['./invoice-list.component.css']
})
export class InvoiceListComponent {
  @Input() invoices: IInvoice[];
  @Output() paymentStatusChanged:EventEmitter<boolean>= new EventEmitter(); 

  constructor(private invoiceService: InvoiceService,private router: Router, private _snackBar: MatSnackBar) {
  }

  displayedColumns: string[] = ['id', 'customerName', 'totalAmount', 'invoiceDate', 'dueDate', 'isPaid', 'action'];

  markStatusAsPaid = (event: any, element: IInvoice) => {
    if (event.selected && !element.isPaid) {
      element.isPaid = true;
      this.invoiceService.markAsPaid(element.id)
        .subscribe({
          next: () => {
            this._snackBar.open("Invoice is marked as paid.", "Success", { duration: 3000 }),
            this.paymentStatusChanged.emit(true);
          },
          error: (error) => console.log(error)
        });
    }
  }

  goToDetails = (id: number) => this.router.navigate([`/details/${id}`]);
}
