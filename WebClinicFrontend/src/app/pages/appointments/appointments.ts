import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { App } from '../../app';

@Component({
  selector: 'app-appointments',
  imports: [FormsModule, CommonModule],
  templateUrl: './appointments.html',
  styleUrl: './appointments.css',
})
export class Appointments {

  constructor(private http: HttpClient, private appListener: App){ }

  // TO DO: appointments, appointments(id)

}
