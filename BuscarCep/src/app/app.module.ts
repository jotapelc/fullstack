import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { LoginComponent } from './modules/login/login.component';
import { BuscarCepComponent } from './modules/buscar-cep/buscar-cep.component';
import { NavComponent } from './core/components/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FooterComponent } from './core/components/footer/footer.component';
import { BuscarCepService } from './core/services/buscar-cep.service';
import { HttpClientModule } from '@angular/common/http';
import { AuthGuard } from './core/guards/auth.guard';
import { LoginService } from './core/services/login.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    BuscarCepComponent,
    NavComponent,
    FooterComponent      
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CommonModule,
    BrowserModule,
    ReactiveFormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    BuscarCepService,
    AuthGuard,
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
