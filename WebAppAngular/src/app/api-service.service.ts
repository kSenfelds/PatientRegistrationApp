import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './patient/patient.component';
import { Doctor } from './doctor';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  constructor(private http: HttpClient) { }

  getPatientData() {
    return this.http.get(`${environment.apiBaseUrl}/api/Registration/GetAllPatients`);
  }

  getDoctorData() {
    return this.http.get(`${environment.apiBaseUrl}/api/Registration/GetAllDoctors`);
  }

  postPatientData(patientData: Patient) {
    return this.http.post(`${environment.apiBaseUrl}/api/Registration/AddPatient`, patientData);
  }

  postDoctorData(doctorData: Doctor) {
    return this.http.post(`${environment.apiBaseUrl}/api/Registration/AddDoctor`, doctorData);
  }

  addPatientToDoctor(patientId: number, doctorId: number) {
    return this.http.post(`${environment.apiBaseUrl}/api/Registration/AddPatientToDoctor?patientId=${patientId}&doctorId=${doctorId}`, null);
  }

  getPatientsByDoctorId(doctorId: number) {
    return this.http.get(`${environment.apiBaseUrl}/api/Registration/GetPatientByDoctor?doctorId=${doctorId}`);
  }

  
}
