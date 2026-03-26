import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login';
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

  constructor(private router: Router, private loginService: LoginService, private appListener: App){ }

  login(){
    if(this.email && this.password){
    this.loginService.checkLogin(this.email, this.password).subscribe({
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
