import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './modules/home/home.component';
import { BuscarCepComponent } from './modules/buscar-cep/buscar-cep.component';
import { LoginComponent } from './modules/login/login.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
   { path: 'login', component: LoginComponent },
   { path: 'buscar-cep', canActivate: [AuthGuard], component: BuscarCepComponent },
   { path: 'home', canActivate: [AuthGuard], component: HomeComponent },
   { path: '', canActivate: [AuthGuard], component: HomeComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
