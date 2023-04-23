import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { InvoiceService } from 'src/app/Services/invoice.service';
import { ICreateInvoice } from 'src/app/models/ListItem';

@Component({
  selector: 'app-invoice-create',
  templateUrl: './invoice-create.component.html',
  styleUrls: ['./invoice-create.component.css']
})
export class InvoiceCreateComponent implements OnInit {
  invoiceForm: FormGroup;
  commonErrorMessage: string = '';
  minDate: Date;
  totalInvoiceAMount = 0;
  constructor(private invoiceService: InvoiceService, private router: Router, private _snackBar: MatSnackBar) {
    this.minDate = new Date();
  }
  ngOnInit() {
    this.invoiceForm = new FormGroup({
      customerName: new FormControl(null, Validators.required),
      dueDate: new FormControl(null, Validators.required),
      listItems: new FormArray([])
    });
  }

  get listItems(): FormArray {
    return this.invoiceForm.get('listItems') as FormArray;
  }

  addItem = (): void => {
    this.listItems.push(this.createItem());
  }

  removeItem = (index: number): void => {
    this.listItems.removeAt(index);
  }

  createItem = (): FormGroup => {
    return new FormGroup({
      description: new FormControl(null, Validators.required),
      quantity: new FormControl(null, Validators.required),
      totalPrice: new FormControl(null, Validators.required)
    });
  }

  onSubmit = (): void => {
    const formData: ICreateInvoice = this.invoiceForm.value;
    if (this.invoiceForm.invalid) {
      this.commonErrorMessage = 'Look for errors in the form';
    }
    else if (formData.listItems.length === 0) {
      this.commonErrorMessage = 'Add one list item at the least';
    }
    else {
      this.invoiceService.createInvoice(formData).subscribe({
        next: () => {
          this._snackBar.open("Invoice is created", "Success", { duration: 3000 }),
            this.router.navigate(['/'])
        },
        error: (error) => console.log(error)
      });
    }
  }

  getTotalInvoiceAmount(): number {
    const listItems = this.invoiceForm.get('listItems') as FormArray;
    let sum = 0;
    listItems.controls.forEach((item) => {
      const totalPrice = item.get('totalPrice')?.value;
      sum += totalPrice ? totalPrice : 0;
    });
    return sum;
  }

  onCancel(): void {
    this.router.navigate(['/']);
  }
}
