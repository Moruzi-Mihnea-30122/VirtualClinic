import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MedicService {
  private apiUrl = "https://localhost:7132/api/medics";

  constructor(private http: HttpClient) { }
  getMedics() {
    return this.http.get<any[]>(this.apiUrl);
  }

  addMedic(medic: {name: string, fieldOfWork: string}) {
    return this.http.post<any>(this.apiUrl, medic);
  }

}
