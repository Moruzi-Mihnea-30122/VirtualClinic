import { Component, OnInit, signal} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AppointmentsService } from '../../services/appointments';
import { MedicService } from '../../services/medics';

@Component({
  selector: 'app-appointments',
  imports: [FormsModule, CommonModule],
  templateUrl: './appointments.html',
  styleUrl: './appointments.css',
})
export class Appointments implements OnInit{
  appointmentsList = signal<any[]>([]);
  medics = signal<any[]>([]);
  wantsAppointment = false;

  date = '';
  time = '';

  newAppointment = {date: '', pacientId: localStorage.getItem('userId')!, medicId: '' };

  times = [ '08:00', '8:15', '08:30','8:45', '09:00','9:15', '09:30','9:45', '10:00','10:15', '10:30', '10:45',
    '11:00','11:15', '11:30','11:45', '12:00', '14:00','14:15', '14:30','14:45', '15:00'];

  constructor(private appointmentsService: AppointmentsService, private medicsService: MedicService){ }

  ngOnInit(): void {
    this.loadAppointments();
    this.medicsService.getMedics().subscribe({
      next:(data) =>{
        this.medics.set(data);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

  loadAppointments(){
    if(localStorage.getItem('userRole') == "Admin")
    {
      this.appointmentsService.getAppointments().subscribe({
        next: (data) => {
          this.appointmentsList.set(data);
          console.log("Appointments loaded: ", data);
        },
        error: (err) => {
          console.log(err);
        }
      })
    }
    else if(localStorage.getItem('userRole') == "Pacient"){
      if(localStorage.getItem('userId') != null){
        this.appointmentsService.getAppointmentsById(localStorage.getItem('userId')!).subscribe({
          next: (data) => {
            this.appointmentsList.set(data);
            console.log("Appointments loaded: ", data);
          },
          error: (err) => {
            console.log(err);
          }
        })
      }
    }
  }

  makeAppointment(){
    this.newAppointment.date= this.date+"T"+this.time+":00";
    console.log(this.newAppointment.date)
    this.appointmentsService.addAppointment(this.newAppointment).subscribe({
      next: () => {
        this.loadAppointments();
      },
      error: (err) => {
        alert("Invalid data. Doctor or Pacient is busy");
      }
    })
  }
  getMedic(medicId: number){
    return this.medics().find(m => m.id == medicId);
  }

}
