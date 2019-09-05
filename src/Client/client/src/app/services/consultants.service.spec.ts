import { TestBed } from '@angular/core/testing';

import { ConsultantsService } from './consultants.service';

describe('ConusltantsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ConsultantsService = TestBed.get(ConsultantsService);
    expect(service).toBeTruthy();
  });
});
