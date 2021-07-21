import { Login } from './../../core/models/login';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms'
import { LoginService } from '../../core/services/login.service';
import { Router } from '@angular/router';
import { AuthService } from '../../core/guards/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup | any;
  public usuario: Login = new Login();

  constructor(
    private formBuilder: FormBuilder,
    private loginService : LoginService,
    private router: Router,
    private auth: AuthService 
  ) { }

  ngOnInit(): void {
    this.construirFormulario();
    this.auth.logout();
    if(localStorage.getItem('avancar') == 'true' ){
      localStorage.setItem('avancar', 'false'); 
    }
  }

  private construirFormulario(): void {
    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      senha: ['', Validators.required]
    });
  }

  setarUsuario(): void{
    this.usuario =  Object.assign({}, this.loginForm.value);
  }

  logar(){
    this.setarUsuario();
    this.loginService.fazerLogin(this.usuario).subscribe(
      (usuario: Login) => {
        localStorage.setItem('isLoggedIn', 'true');  
        localStorage.setItem('user', usuario.login); 
        this.router.navigate(['']);
      });
    }

    logout(){
      this.router.navigate(['/login']);
    }
   
}
