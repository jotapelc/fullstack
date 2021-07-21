import { Login } from './../models/login';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  baseURI = environment.apiUrl;

  fazerLogin(login : Login) : Observable<Login>{

    return this.http.post<Login>(this.baseURI + '/Usuario/authenticate', login)
    
  }
}
