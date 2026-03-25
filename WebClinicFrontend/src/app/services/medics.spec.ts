import { TestBed } from '@angular/core/testing';

import { Medic } from './medics';

describe('Medics', () => {
  let service: Medic;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Medic);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
