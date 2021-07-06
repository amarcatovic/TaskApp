import { TestBed } from '@angular/core/testing';

import { EditTaskService } from './edit-task.service';

describe('EditTaskService', () => {
  let service: EditTaskService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EditTaskService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
