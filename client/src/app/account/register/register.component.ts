import { Component, OnInit } from '@angular/core';
import { AsyncValidatorFn, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { Router } from '@angular/router';
import { map, of, switchMap, timer } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  errors: string[];

  constructor(private formBuilder: FormBuilder,
    private accountService: AccountService, private router:
    Router){

  }
  ngOnInit(){
    this.createRegisterForm();
  }

  createRegisterForm(){
    this.registerForm = this.formBuilder.group({
      displayName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
      [this.validateEmailNotTaken()]],
      password: [null, [Validators.required]]
    });
  }
  onSubmit(){
    this.accountService.register(this.registerForm.value).subscribe({
      next: (response) => this.router.navigateByUrl('/shop'),
      error: (error) => {
        console.log(error)
        this.errors = error.errors
      }
    })
  }
  validateEmailNotTaken(): AsyncValidatorFn{
    return control => {
      return timer(1000).pipe(
        switchMap(() => {
          if(!control.value){
            return of(null);
          }
          return this.accountService.checkEmailExists(control.value).pipe(
            map(res => {
              return res ? {emailExists: true} : null
            })
          );
        })
      );
    }
  }
}
