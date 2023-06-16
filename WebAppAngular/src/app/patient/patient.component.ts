import { Component, OnInit } from '@angular/core';
import { CommonModule} from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiServiceService } from '../api-service.service';
import { Patient } from '../patient';
import { Doctor } from '../doctor';



@Component({
  selector: 'app-patient',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css']
})
export class PatientComponent implements OnInit {
    selectedDoctorId: number | null = null;
    patientData: Patient[] = [];
    doctorData: Doctor[] = [];
    constructor(private apiService: ApiServiceService) { }
    ngOnInit(): void {
      this.apiService.getDoctorData().subscribe(data=>{
        this.doctorData = data as Doctor[];
      });
      this.fetchFilteredPatients();
    }

    fetchFilteredPatients(): void {
      if (this.selectedDoctorId){
        this.apiService.getPatientsByDoctorId(this.selectedDoctorId).subscribe(data=>{
          this.patientData = data as Patient[];
        });
      } else {
        this.apiService.getPatientData().subscribe(data=>{
          this.patientData = data as Patient[];
        });
      }
    }
   
    onDoctorSelectionChange(): void {
      this.fetchFilteredPatients();
    }
    
    editData(patient: Patient, doctor: Doctor): void {
      this.apiService.addPatientToDoctor(patient.id!, doctor.id!).subscribe(data=>{
        console.log(data);
      });
    }
    getDoctorById(id: number): Doctor | undefined{
      return this.doctorData.find(x => x.id == id);
    }
}
export { Patient };
export { Doctor };

