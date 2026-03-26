import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class LoginService {

  constructor(private http: HttpClient) {}

  checkLogin(email : string, password : string ){
    return this.http.post('https://localhost:7132/api/Pacients/login', { email, password });
  }
}
