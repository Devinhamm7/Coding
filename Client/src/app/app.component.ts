import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Supervisor } from './models/Supervisor';
import { FormService } from './Services/form.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent{
  baseUrl = environment;
  title = 'Client';
  model: any = {};
  data:any = []
  value :any

  constructor(private formService: FormService, private http: HttpClient) {}
  supervisors: string[] = [];

  ngoninit(): void {
    this.loadSupervisors();
  }

  submit(){
    this.formService.submit(this.model).subscribe(response => {
      console.log(response);
    }, error =>{
      console.log(error);
    })
  }

  loadSupervisors(){
    this.http.get(this.baseUrl + '/supervisor').subscribe((res) => {
      this.data = res

    })
  }

  onItemChange(value: any){
    console.log();
 }
}

