import { TestBed } from '@angular/core/testing';

import { BioDataServiceService } from './BioDataService.service';

describe('BioDataServiceService', () => {
  let service: BioDataServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BioDataServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
