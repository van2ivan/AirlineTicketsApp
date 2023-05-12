import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  validationErrors: any;

  constructor(private http: HttpClient){
  }
    ngOnInit(){

    }

    get404Error(){
      this.http.get(this.baseUrl + 'errorstesting/notfound').subscribe({
        next: (response) => console.log(response),
        error: (error) => console.log(error)
      });
    }

    get400Error(){
      this.http.get(this.baseUrl + 'errorstesting/badrequest').subscribe({
        next: (response) => console.log(response),
        error: (error) => console.log(error)
      });
    }

    get400ValidationError(){
      this.http.get(this.baseUrl + 'flights/fourtythousand').subscribe({
        next: (response) => console.log(response),
        error: (error) => {
          console.log(error);
          this.validationErrors = error.errors;
        }
      });
    }

    get500Error(){
      this.http.get(this.baseUrl + 'errorstesting/servererror').subscribe({
        next: (response) => console.log(response),
        error: (error) => console.log(error)
      });
    }


}



