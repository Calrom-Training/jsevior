import { TestBed } from '@angular/core/testing';

import { LogOnService } from './log-on.service';

describe('LogOnService', () => {
  let service: LogOnService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LogOnService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
