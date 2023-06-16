import { Component } from '@angular/core';
import { ApiServiceService } from '../api-service.service';

@Component({
  selector: 'app-doctor-registration',
  templateUrl: './doctor-registration.component.html',
  styleUrls: ['../registration-form/registration-form.component.css'],
  standalone: true,
})
export class DoctorRegistrationComponent {
  constructor(private apiService: ApiServiceService) { }

  saveData() {
    event!.preventDefault();
    const firstName = document.getElementById('doctor-name') as HTMLInputElement;
    const lastName = document.getElementById('dlast-name') as HTMLInputElement;
    const specialty = document.getElementById('specialty') as HTMLInputElement;
    const phoneNumber = document.getElementById('dphone-number') as HTMLInputElement;


    const doctorData = {
      name: firstName.value,
      lastName: lastName.value,
      specialization: specialty.value,
      phoneNumber: phoneNumber.value,
      patients: []
    };
    

    this.apiService.postDoctorData(doctorData).subscribe(data => {
      console.log(data);
    });

  }
}
