import { Component, signal, OnInit} from '@angular/core';
import { PacientsService } from '../../services/pacients';
import { FormsModule } from '@angular/forms';
import { App } from '../../app';

@Component({
  selector: 'app-pacients',
  imports: [FormsModule],
  templateUrl: './pacients.html',
  styleUrl: './pacients.css',
})
export class Pacients {
  pacients = signal<any[]>([]);

  newPacient = {name: '', emailAddress: '', telNumber: '', password: 'default', role: 'Pacient'};

  constructor(private pacientsService: PacientsService, private appListener: App){ }

  ngOnInit():void{
    this.loadPacients();
  }

  getUserRole(){
    return this.appListener.userRole();
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

  deletePacient(pacientId: number){
    this.pacientsService.removePacient(pacientId);
  }
}
