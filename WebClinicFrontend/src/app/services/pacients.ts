import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PacientsService {
  private apiUrl = "https://localhost:7132/api/pacients";

  constructor(private http: HttpClient){ }

  getPacients(){
    return this.http.get<any[]>(this.apiUrl).pipe(
      map(users => users.filter(user => user.role != "Admin"))
    );
  }

  addPacient(pacient: {name: string, emailAddress: string, telNumber: string, password: string, role: string}){
    return this.http.post<any>(this.apiUrl, pacient);
  }

}
