import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PacientsService {
  private apiUrl = "https://localhost:7132/api/pacients";

  constructor(private http: HttpClient){ }

  getPacients(){
    return this.http.get<any[]>(this.apiUrl);
  }

  addPacient(pacient: {name: string, emailAddress: string, telNumber: string}){
    return this.http.post<any>(this.apiUrl, pacient);
  }

}
