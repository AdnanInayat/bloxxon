import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { CustomerCombo } from 'src/app/core/models/customerCombo';

import { Invoice } from '../../core/models/invoice';
import { DataService } from '../../core/services/data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  searchText: string = '';
  invoices: Invoice[] = [];
  customersCombo: CustomerCombo[] = [];
  newInvoice: Invoice = {id:'0', amount: 0, deadline: new Date(), customerId: '0'};
  selectedInvoice: Invoice = {id:'0', amount: 0, deadline: new Date(), customerId: '0'};
  selectedInvoicesIds: Number[] = [];
  successMsg: string = ''
  errorMsg: string = ''
  showSuccess: boolean = false;
  showError: boolean = false;
  showDetailsModal: boolean = false;

  constructor(private dataService: DataService, 
    private router: Router) 
    { }

  ngOnInit(): void {
    this.getInvoices();
    this.getCustomersForCombo();
  }

  getInvoices(): void{
    this.dataService
      .getInvoices()
      .subscribe(invoices => this.invoices = invoices);
    this.selectedInvoicesIds = [];
  }
  getCustomersForCombo(): void{
    this.dataService
      .getCustomersForCombo()
      .subscribe(customers => this.customersCombo = customers);
  }
  showDetails(id: string): void {
    this.getInvocie(id).subscribe(invoice => {
      if(invoice) {
        this.selectedInvoice = invoice;
        this.showDetailsModal = true;
      }
    });
  }

  getInvocie(id: string): Observable<Invoice>{
    if(id){
      return this.dataService.getInvoice(id);
    }
    return EMPTY;
  }

  search(): void {
    if (!this.searchText)
      return;

    this.dataService
      .getInvoices()
      .subscribe(invoices => {
        const filteredInvoices = invoices.filter(c => c.id == this.searchText);
        this.invoices = filteredInvoices;
      });
  }
  updateInvoice(): void{
    this.showError = false;
    this.showSuccess = false;
    if(this.selectedInvoice){
      this.dataService.saveInvoice(this.selectedInvoice).subscribe(res => {
        if(res){
          this.successMsg = "Invoice updated successfully.";
          this.showSuccess = true;
        }
        else{
          this.errorMsg = "Something went wrong please try again.";
          this.showError = true;
        }
      });
    }
  }
  addInvoice(): void{
    this.showError = false;
    this.showSuccess = false;
    if(this.newInvoice){
      this.dataService.saveInvoice(this.newInvoice).subscribe(res => {
        if(res){
          this.successMsg = "Invoice added successfully.";
          this.newInvoice = {id:'0', amount: 0, deadline: new Date(), customerId: '0'};
          this.showSuccess = true;
        }
        else{
          this.errorMsg = "Something went wrong please try again.";
          this.showError = true;
        }
      });
    }
  }
  deleteInvoices(): void{
    if(this.selectedInvoicesIds.length > 0){
      this.dataService.deleteInvoices(this.selectedInvoicesIds).subscribe(res => {
        if(res){
          this.successMsg = "Invoice(s) deleted successfully.";
          this.selectedInvoicesIds = [];
          this.showSuccess = true;
        }
        else{
          this.errorMsg = "Something went wrong please try again.";
          this.showError = true;
        }
      });
    }
  }
  checkboxChange(e: any, id: string):void {
    let intId = parseInt(id);
    let arrayIndx = this.selectedInvoicesIds.indexOf(intId);
    if(e.target.checked && arrayIndx < 0){
      this.selectedInvoicesIds.push(intId);
    }
    else if(!e.target.checked && arrayIndx >= 0){
      this.selectedInvoicesIds.splice(arrayIndx,1);
    }
  }
  closeModal(): void{
    this.showError = false;
    this.showSuccess = false;
    this.showDetailsModal = false;
  }
  closeModalAndRefresh(): void{
    this.showError = false;
    this.showSuccess = false;
    this.showDetailsModal = false;
    this.getInvoices();
  }
}
