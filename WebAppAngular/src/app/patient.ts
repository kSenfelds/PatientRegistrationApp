import { Doctor } from "./doctor";

export interface Patient {
    id?: number;
    name: string;
    lastName: string;
    address: string;
    phoneNumber: string;
    doctorId?: number;
    doctor?: Doctor;
}
