import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReplaySubject } from 'rxjs';

import {map} from 'rxjs/operators';

import { User } from '../models/User';
import { Supervisor } from '../models/Supervisor';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FormService {

  baseUrl = environment;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  submit(model: any){
    return this.http.post<User>(this.baseUrl + '/submit', model).pipe(
        map((user: User) => {
          if(user) {
             localStorage.setItem('user', JSON.stringify(user));
             this.currentUserSource.next(user);
          }
          return user;
      })
    )
  }
}
