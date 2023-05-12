import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-checkout-details',
  templateUrl: './checkout-details.component.html',
  styleUrls: ['./checkout-details.component.scss']
})
export class CheckoutDetailsComponent implements OnInit{
  @Input() checkoutForm: FormGroup;
  constructor(private accountService: AccountService,
    private toastr: ToastrService){

  }
  ngOnInit(){

  }
  saveUserDetails(){
    this.accountService.updateUserDetails(
      this.checkoutForm.get('detailsForm').value).subscribe({
        next: () => this.toastr.success('Details saved'),
        error: (error) => {
          this.toastr.error(error.message);
          console.log(error);
        }
      })

  }
}
