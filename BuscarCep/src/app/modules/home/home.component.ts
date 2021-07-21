import { Component, OnInit } from '@angular/core';
import { Login } from '../../core/models/login';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public usuario: Login;

  constructor() { }

  ngOnInit(): void {
  }

}
