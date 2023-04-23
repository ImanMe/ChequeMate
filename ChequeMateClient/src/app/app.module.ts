import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { AppComponent } from './app.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatBadgeModule } from '@angular/material/badge';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatChipsModule } from '@angular/material/chips';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDialogModule } from '@angular/material/dialog';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatRadioModule } from '@angular/material/radio';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { InvoiceComponent } from './invoice/invoice.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InvoiceListComponent } from './invoice/invoice-list/invoice-list.component';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { InvoiceDetailsComponent } from './invoice/invoice-details/invoice-details.component';
import { RouterModule } from '@angular/router';
import { InvoiceCreateComponent } from './invoice/invoice-create/invoice-create.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { SpinnerComponent } from './shared/spinner/spinner.component';

@NgModule({
  declarations: [
    AppComponent,
    InvoiceComponent,
    InvoiceListComponent,
    InvoiceDetailsComponent,
    InvoiceCreateComponent,
    SpinnerComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSlideToggleModule,
    MatExpansionModule,
    MatInputModule,
    MatBadgeModule,
    MatButtonToggleModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatListModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatSnackBarModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatNativeDateModule, 
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: InvoiceComponent, pathMatch: 'full' },
      { path: 'create', component: InvoiceCreateComponent },
      { path: 'details/:id', component: InvoiceDetailsComponent },
      { path: '**', component: AppComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
