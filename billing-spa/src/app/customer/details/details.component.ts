import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EMPTY } from 'rxjs';
import { Customer } from 'src/app/core/models/customer';
import { DataService } from 'src/app/core/services/data.service';


@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  id: string = '';
  customer : Customer = { id : '', firstname : '', lastname : ''};
  successMsg: string = ''
  errorMsg: string = ''
  showSuccess: boolean = false;
  showError: boolean = false;

  apiUrl = "http://localhost:5000";
  
  constructor(private route: ActivatedRoute, private router: Router, private dataService: DataService) { 
    route.params.subscribe(
      (params) => {
        this.id = params['id'];
      });
  }

  ngOnInit(): void {
    this.getCustomer();
  }

  getCustomer() : void{
    if(this.id){
      this.dataService
      .getCustomer(this.id)
      .subscribe(customer => {
        if(customer) 
          this.customer = customer;
      });
    }
  }
  saveCustomer(): void{
    this.showError = false;
    this.showSuccess = false;
    if(this.customer){
      this.dataService.saveCustomer(this.customer).subscribe(res => {
        if(res){
          this.successMsg = "Customer updated successfully.";
          this.showSuccess = true;
          this.getCustomer();
        }
        else{
          this.errorMsg = "Something went wrong please try again.";
          this.showError = true;
        }
      });
    }
  }
  deleteCustomer(): void{
    if(this.customer.invoices!.length <= 0){
      this.dataService.deleteCustomer(this.customer.id).subscribe(res => {
        if(res){
          this.successMsg = "Customer deleted successfully.";
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
  }
  closeDelModal(): void{
    this.router.navigate(['customer']);
  }
  onFileChange(event:any): void {
    const reader = new FileReader();
    
    if(event.target.files && event.target.files.length) {
      const [file] = event.target.files;
      reader.readAsDataURL(file);
      this.customer.imgUrl = file.name;
      reader.onload = () => {        
        this.customer.profileImage = reader.result as string;
      };
      
    }
  }
}
