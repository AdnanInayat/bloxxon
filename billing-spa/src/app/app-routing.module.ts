import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'customer', loadChildren: () => import('./customer/customer.module').then((m) => m.CustomerModule), },
  { path: 'invoice', loadChildren: () => import('./invoice/invoice.module').then((m) => m.InvoiceModule), },
  { path: '**', redirectTo: '/customer' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
