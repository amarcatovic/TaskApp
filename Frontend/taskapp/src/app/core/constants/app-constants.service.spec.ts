import { TestBed } from '@angular/core/testing';

import { AppConstantsService } from './app-constants.service';

describe('AppConstantsService', () => {
  let service: AppConstantsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppConstantsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
