import { BuscarCepService } from './../../core/services/buscar-cep.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BuscarCep } from './../../core/models/buscar-cep';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-buscar-cep',
  templateUrl: './buscar-cep.component.html',
  styleUrls: ['./buscar-cep.component.css']
})
export class BuscarCepComponent implements OnInit {

  public cep: string;
  public endereco: BuscarCep = new BuscarCep();

  constructor(
    private bucarCepService: BuscarCepService,
    private router: Router
  ) { }

  ngOnInit(): void {

  }

  BuscarCep(): void {
    if(this.cep.length == 8){
    this.bucarCepService.buscarCep(this.cep.replace("-", "")).subscribe(enderecos => {
      this.endereco = enderecos;
    });
    }
    else {
      alert('O CEP deve conter 8 digitos');
    }
  }
}
