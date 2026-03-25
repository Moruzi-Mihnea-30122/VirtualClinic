import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { App } from '../../app';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
   email = '';
   password = '';

  constructor(private router: Router, private http: HttpClient, private appListener: App){ }

  login(){
    this.http.post('https://localhost:7132/api/Pacients/login', { email: this.email, password: this.password }).subscribe((user: any) => {
        localStorage.setItem('userRole', user.role);
        localStorage.setItem('userId', user.id);

        this.appListener.checkUserStatus();

        this.router.navigate(['/home']);
    })
  }
}
