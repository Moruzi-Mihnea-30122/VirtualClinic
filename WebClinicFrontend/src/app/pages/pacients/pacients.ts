import { Component, signal, OnInit} from '@angular/core';
import { PacientsService } from '../../services/pacients';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-pacients',
  imports: [FormsModule],
  templateUrl: './pacients.html',
  styleUrl: './pacients.css',
})
export class Pacients {
  pacients = signal<any[]>([]);

  newPacient = {name: '', emailAddress: '', telNumber: '', password: 'default', role: 'Pacient'};

  constructor(private pacientsService: PacientsService){ }

  ngOnInit():void{
    this.loadPacients();
  }

  loadPacients():void{
    this.pacientsService.getPacients().subscribe({
      next: (data) => {
        this.pacients.set(data)
        console.log("Pacienti: ", data)
      }
    })
  }

  addPacient():void{
    if(this.newPacient.name && this.newPacient.emailAddress && this.newPacient.telNumber)
    { 
      this.pacientsService.addPacient(this.newPacient).subscribe({
        next: (response) => {
          console.log("Pacient added: ", response);
          this.loadPacients();
        }
      });
      this.newPacient = {name: '', emailAddress: '', telNumber: '', password: 'default', role: 'Pacient'};
      
    }
  }
}
