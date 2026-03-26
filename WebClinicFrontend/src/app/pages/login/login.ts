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
    if(this.email && this.password){
    this.http.post('https://localhost:7132/api/Pacients/login', { email: this.email, password: this.password }).subscribe({
      next: (user: any) => {
        localStorage.setItem('userRole', user.role);
        localStorage.setItem('userId', user.id);

        this.appListener.checkUserStatus();

        this.router.navigate(['/home']);
      },
      error: (err) => {
        alert("User not found");
      }
    })
  }else{
    alert("Please fill up the blanks");
  }
}

  registerNav(){
    this.router.navigate(['/register']);
  }
}
