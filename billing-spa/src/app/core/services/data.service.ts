import { Injectable } from '@angular/core';
import { EMPTY, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { Customer } from '../models/customer';
import { Invoice } from '../models/invoice';
import { CustomerCombo } from '../models/customerCombo';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  private apiUrl = "http://localhost:5000/";

  // TODO: Get the customer data from the billing-api
  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl + "customer");
  }
  searchCustomers(q:string): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl + `customer/search?query=${q}`);
  }

  saveCustomer(customer: Customer): Observable<Boolean> {
    return this.http.post<Boolean>(this.apiUrl + "customer",customer);
  }

  // TODO: Get the customer data from the billing-api
  getCustomer(id: string): Observable<Customer> {
    return this.http.get<Customer>(this.apiUrl + `customer/${id}`);
  }
  getCustomersForCombo(): Observable<CustomerCombo[]> {
    return this.http.get<CustomerCombo[]>(this.apiUrl + "customer/combo" );
  }

  deleteCustomer(id: string): Observable<Boolean> {
    return this.http.delete<Boolean>(this.apiUrl + `customer/${id}`);
  }

  getInvoices(): Observable<Invoice[]> {
    return this.http.get<Invoice[]>(this.apiUrl + "invoice");
  }

  saveInvoice(invoice: Invoice): Observable<Boolean> {
    return this.http.post<Boolean>(this.apiUrl + "invoice", invoice);
  }

  // TODO: Get the customer data from the billing-api
  getInvoice(id: string): Observable<Invoice> {
    return this.http.get<Invoice>(this.apiUrl + `invoice/${id}`);
  }

  deleteInvoices(ids: Number[]): Observable<Boolean> {
    return this.http.post<Boolean>(this.apiUrl + "invoice/Delete", ids);
  }

  // TODO: We should be able to see a list of invoices for each customer
  // TODO: We should be able to create new customers and invoices
  // TODO: We should be able to delete invoices and customers
  // BONUS: We should be able to search for customers by name or email

}

const Customers: Customer[] = [
  { id: "0001", firstname: "Tony", lastname: "Stark", email: "t.start@bloxxon.co", },
  { id: "0002", firstname: "Peter", lastname: "Parker", email: "p.parker@bloxxon.co", },
  { id: "0003", firstname: "Bruce", lastname: "Banner", email: "b.banner@bloxxon.co", },
];
