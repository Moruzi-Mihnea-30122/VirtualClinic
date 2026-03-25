import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Appointments {
  private apiUrl = "https://localhost:7132/api/appointments";

  constructor(private http: HttpClient){}

  getAppointments(){
    this.http.get<any[]>(this.apiUrl);
  }

  //TO DO: addAppointment
}
