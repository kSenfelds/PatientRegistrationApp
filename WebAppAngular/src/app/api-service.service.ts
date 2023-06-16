import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from './patient/patient.component';
import { Doctor } from './doctor';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  constructor(private http: HttpClient) { }

  getPatientData() {
    return this.http.get('https://localhost:7231/api/Registration/GetAllPatients');
  }

  getDoctorData() {
    return this.http.get('https://localhost:7231/api/Registration/GetAllDoctors');
  }

  postPatientData(patientData: Patient) {
    return this.http.post('https://localhost:7231/api/Registration/AddPatient', patientData);
  }

  postDoctorData(doctorData: Doctor) {
    return this.http.post('https://localhost:7231/api/Registration/AddDoctor', doctorData);
  }

  addPatientToDoctor(patientId: number, doctorId: number) {
    return this.http.post('https://localhost:7231/api/Registration/AddPatientToDoctor?patientId=' + patientId + '&doctorId=' + doctorId, null);
  }

  getPatientsByDoctorId(doctorId: number) {
    return this.http.get('https://localhost:7231/api/Registration/GetPatientByDoctor?doctorId=' + doctorId);
  }

  
}
