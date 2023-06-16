import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { PatientComponent } from './patient/patient.component';
import {  HttpClientModule } from '@angular/common/http';
import { DoctorRegistrationComponent } from './doctor-registration/doctor-registration.component';
import { NavigationComponent } from './navigation/navigation.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    
  ],
  imports: [
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    RegistrationFormComponent,
    PatientComponent,
    HttpClientModule,
    DoctorRegistrationComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
