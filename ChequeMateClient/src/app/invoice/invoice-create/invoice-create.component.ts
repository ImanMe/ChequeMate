import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { IInvoice } from 'src/app/models/ListItem';

@Component({
  selector: 'app-invoice-create',
  templateUrl: './invoice-create.component.html',
  styleUrls: ['./invoice-create.component.css']
})
export class InvoiceCreateComponent implements OnInit {
  invoiceForm: FormGroup;;
  ngOnInit() {
    this.invoiceForm = new FormGroup({
      invoiceDate: new FormControl(null, Validators.required),
      customerName: new FormControl(null, Validators.required),
      dueDate: new FormControl(null, Validators.required),
      listItems: new FormArray([])
    });
  }

  get listItems(): FormArray {
    return this.invoiceForm.get('listItems') as FormArray;
  }

  addItem(): void {
    this.listItems.push(this.createItem());
  }

  removeItem(index: number): void {
    this.listItems.removeAt(index);
  }

  createItem(): FormGroup {
    return new FormGroup({
      description: new FormControl(null, Validators.required),
      quantity: new FormControl(null, Validators.required),
      totalPrice: new FormControl(null, Validators.required)
    });
  }

  onSubmit(): void {
    const formData: IInvoice = this.invoiceForm.value;
    console.log(formData);
  }
}
