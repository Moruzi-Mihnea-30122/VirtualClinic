import { Component, signal, OnInit} from '@angular/core';
import { RouterOutlet , RouterLink, Router} from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
userRole = signal<string | null>(localStorage.getItem("userRole"));

constructor(private router: Router){ }

logout(){
  localStorage.clear();
  this.userRole.set(null);
  this.router.navigate(['/login']);
}

checkUserStatus(){
  this.userRole.set(localStorage.getItem('userRole'));
}
}
