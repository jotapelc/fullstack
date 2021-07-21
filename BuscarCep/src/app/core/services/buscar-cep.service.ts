import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { BuscarCep } from '../models/buscar-cep';

@Injectable({
  providedIn: 'root'
})
export class BuscarCepService {

  constructor(private http: HttpClient) { }

  baseURI = environment.apiUrl;

  buscarCep(cep: string): Observable<BuscarCep> | any {
    return this.http
    .get(this.baseURI + '/BuscarCep/' + cep)
  }
}
