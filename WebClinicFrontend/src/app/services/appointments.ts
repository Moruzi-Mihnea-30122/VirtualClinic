import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AppointmentsService {
  private apiUrl = "https://localhost:7132/api/appointments";

  constructor(private http: HttpClient){}

  getAppointments(){
   return this.http.get<any[]>(this.apiUrl);
  }

  getAppointmentsById(id: string){
   return this.http.get<any[]>(this.apiUrl +'/'+ id);
  }

  addAppointment(appointment: {date: string, pacientId: string, medicId: string}){
    return this.http.post<any>(this.apiUrl, appointment)
  }
}
