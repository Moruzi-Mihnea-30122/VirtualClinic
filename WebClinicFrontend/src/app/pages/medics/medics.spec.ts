import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MedicsComponent } from './medics';

describe('Medics1', () => {
  let component: MedicsComponent;
  let fixture: ComponentFixture<MedicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MedicsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MedicsComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
