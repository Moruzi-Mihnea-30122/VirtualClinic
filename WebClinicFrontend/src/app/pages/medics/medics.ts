import { Component, signal, OnInit} from '@angular/core';
import { MedicService } from '../../services/medics';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { App } from '../../app';

@Component({
  selector: 'app-medics',
  imports: [ CommonModule, FormsModule],
  templateUrl: './medics.html',
  styleUrl: './medics.css'
})
export class MedicsComponent implements OnInit{
   medics = signal<any[]>([]);

   newMedic = {name:'', fieldOfWork:'' };

  constructor(private medicService : MedicService, private appListener: App){ }

  getUserRole(){
    return this.appListener.userRole();
  }

  ngOnInit():void{
    console.log("Loaded");
    this.loadMedics();
  }

  loadMedics():void{ 
    this.medicService.getMedics().subscribe({
      next: (data) => {this.medics.set(data);
                      console.log('Medici primiti', this.medics())}
    })
  }

  saveMedic():void{
    if(this.newMedic.name && this.newMedic.fieldOfWork){
      this.newMedic = {name: 'Dr. ' + this.newMedic.name, fieldOfWork: this.newMedic.fieldOfWork}
      this.medicService.addMedic(this.newMedic).subscribe({
        next: (response) => {
          console.log("Medic added", response);
          this.newMedic = {name:'', fieldOfWork:'' };
          this.loadMedics();
        }
      })
    }
  }

  deleteMedic(medicId: number):void{
    this.medicService.deleteMedic(medicId).subscribe({
      next: (data) => {
        console.log("Medic deleted", data);
        this.loadMedics();
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
 
}
