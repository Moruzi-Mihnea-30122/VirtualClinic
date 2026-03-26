import { Component, Inject, Injectable } from '@angular/core';
import { PacientsService } from '../../services/pacients';
import { FormsModule } from '@angular/forms';
import { Login } from '../login/login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
newUser = {name: '', emailAddress: '', telNumber: '', password: '', role: 'Pacient'};
checkedPassword = '';
constructor(private pacientsService: PacientsService, private router: Router) { }

registerUser(){
  if(this.newUser.emailAddress && this.newUser.name && this.newUser.password && this.newUser.telNumber && this.checkedPassword){
    if(this.newUser.password == this.checkedPassword){
      this.pacientsService.addPacient(this.newUser).subscribe({
        next: (data) => {
          this.newUser = {name: '', emailAddress: '', telNumber: '', password: '', role: 'Pacient'};
          console.log("User added: ", data);
          this.router.navigate(['/login'])
        },
        error: (err) => {
          alert("Invalid user");
          throw new Error(err);
        }
      });
    }
    else{
      alert("Passwords dosen't match");
    }
  }else{
    alert("Please fill all the blanks");
  }
}

loginNav(){
  this.router.navigate(['/login']);
}


}
