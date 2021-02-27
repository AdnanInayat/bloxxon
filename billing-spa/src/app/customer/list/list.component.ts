import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Customer } from '../../core/models/customer';
import { DataService } from '../../core/services/data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  
  searchText: string = '';
  customers: Customer[] = [];
  nCustomer: Customer = {id:'0', firstname: '', lastname: ''};
  successMsg: string = ''
  errorMsg: string = ''
  showSuccess: boolean = false;
  showError: boolean = false;
  
  constructor(private dataService: DataService, private router: Router) { }
  
  ngOnInit(): void {
    this.getCustomers();
  }
  
  showDetails(id: string): void {
    this.router.navigate(['customer', id]);
  }
  
  getCustomers(): void{
    this.dataService
    .getCustomers()
    .subscribe(customers => this.customers = customers);
  }
  
  // BONUS: Filter the result set on the backend side
  search(): void {
    this.dataService
    .searchCustomers(this.searchText)
    .subscribe(customers => {
      this.customers = customers;
    });
  }

  saveCustomer(): void{
    this.showError = false;
    this.showSuccess = false;
    if(this.nCustomer){
      this.dataService.saveCustomer(this.nCustomer).subscribe(res => {
        if(res){
          this.successMsg = "Customer added successfully.";
          this.nCustomer = {id:'0', firstname: '', lastname: ''};
          this.showSuccess = true;
        }
        else{
          this.errorMsg = "Something went wrong please try again.";
          this.showError = true;
        }
      });
    }
  }
  closeModal(): void{
    this.showError = false;
    this.showSuccess = false;
    this.getCustomers();
  }
  
  onFileChange(event:any): void {
    const reader = new FileReader();
    
    if(event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);
      this.nCustomer.imgUrl = file.name;
      reader.onload = () => {        
        this.nCustomer.profileImage = reader.result as string;
      };
      
    }
  }
}
