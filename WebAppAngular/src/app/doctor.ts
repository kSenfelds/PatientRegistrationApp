import { Patient } from "./patient";

export interface Doctor {
    id?: number;
    name: string;
    lastName: string;
    specialization: string;
    phoneNumber: string;
    patients: Patient[];
}
