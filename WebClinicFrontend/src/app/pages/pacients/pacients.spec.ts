import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Pacients } from './pacients';

describe('Pacients', () => {
  let component: Pacients;
  let fixture: ComponentFixture<Pacients>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Pacients],
    }).compileComponents();

    fixture = TestBed.createComponent(Pacients);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
