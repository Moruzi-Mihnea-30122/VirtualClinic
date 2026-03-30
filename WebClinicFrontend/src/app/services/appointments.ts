import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Appointments } from '../pages/appointments/appointments';

@Injectable({
  providedIn: 'root',
})
export class AppointmentsService {
  private apiUrl = "https://localhost:7132/api/appointments";

  constructor(private http: HttpClient){}

  getAppointments(){
   return this.http.get<any[]>(this.apiUrl);
  }

  getAppointmentsByPacientId(id: string){
   return this.http.get<any[]>(`${this.apiUrl}?pacientId=${id}`);
  }

  addAppointment(appointment: {date: string, pacientId: string, medicId: string}){
    return this.http.post<any>(this.apiUrl, appointment)
  }
  deleteAppointment(id: number){
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}
