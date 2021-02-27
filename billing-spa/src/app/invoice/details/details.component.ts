import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EMPTY } from 'rxjs';
import { Invoice } from 'src/app/core/models/invoice';
import { DataService } from 'src/app/core/services/data.service';


@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  id: string = '';
  invoice : Invoice = { id : '0', amount : 0, deadline : new Date(), customerId : '0'};
  successMsg: string = ''
  errorMsg: string = ''
  showSuccess: boolean = false;
  showError: boolean = false;

  constructor(private route: ActivatedRoute, private dataService: DataService) { 
    route.params.subscribe(
      (params) => {
        this.id = params['id'];
      });
  }

  ngOnInit(): void {
    this.getInvoice();
  }

  getInvoice() : void{
    if(this.id){
      this.dataService
      .getInvoice(this.id)
      .subscribe(invoice => {
        if(invoice) 
          this.invoice = invoice;
      });
    }
  }
  saveInvoice(): void{
    this.showError = false;
    this.showSuccess = false;
    if(this.invoice){
      this.dataService.saveInvoice(this.invoice).subscribe(res => {
        if(res){
          this.successMsg = "Invoice updated successfully.";
          this.showSuccess = true;
          this.getInvoice();
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
}
