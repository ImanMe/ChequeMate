import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceService } from 'src/app/Services/invoice.service';
import { IInvoice, IListItem } from 'src/app/models/ListItem';

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit{

  constructor(private invoiceService:InvoiceService, private route: ActivatedRoute, private router: Router){
  }

  invoice: IInvoice;
  listItems: IListItem[];

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.getInvoice(params['id']);
    });
  }
  
  getInvoice = (id: number) => {
    this.invoiceService.getInvoice(id).subscribe({
      next: (result) => {
        this.invoice = result,
        this.listItems = this.invoice.listItems
      },
      error: (error) => console.log(error)
    });
  }

  onBackClick = () => {
    this.router.navigate(['/']);
  }
}
