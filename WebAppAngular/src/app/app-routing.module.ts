import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorRegistrationComponent } from './doctor-registration/doctor-registration.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { PatientComponent } from './patient/patient.component';

const routes: Routes = [
  { path: 'add-patient', component: RegistrationFormComponent },
  { path: 'add-doctor', component: DoctorRegistrationComponent },
  { path: 'manage-patients', component: PatientComponent },
  { path: '', redirectTo: '/add-patient', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
