import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiServiceService } from '../api-service.service';

@Component({
  selector: 'app-registration-form',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h1>Patient Registration</h1>
    <form class="registration-form">
      <div class="registration-form__input-group">
        <label for="first-name">First Name</label>
        <input id="first-name" type="text" />
        <label for="last-name">Last Name</label>
        <input id="last-name" type="text" />
        <label for="address">Address</label>
        <input id="address" type="text" />
        <label for="phone-number">Phone number</label>
        <input id="phone-number" type="text" />
        <button class="primary" type="submit" (click)= "saveData()">Save</button>
      </div>
    </form>
  `,
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent {
  constructor(private apiService: ApiServiceService) { }
  saveData(): void {
    const firstName = document.getElementById('first-name') as HTMLInputElement;
    const lastName = document.getElementById('last-name') as HTMLInputElement;
    const address = document.getElementById('address') as HTMLInputElement;
    const phoneNumber = document.getElementById('phone-number') as HTMLInputElement;

    const patientData = {
      name: firstName.value,
      lastName: lastName.value,
      address: address.value,
      phoneNumber: phoneNumber.value
    };
    this.apiService.postPatientData(patientData).subscribe(data => {
      console.log(data);
    }
    );
  }
}
