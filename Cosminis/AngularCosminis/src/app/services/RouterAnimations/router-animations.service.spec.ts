import { TestBed } from '@angular/core/testing';

import { RouterAnimationsService } from './router-animations.service';

describe('RouterAnimationsService', () => {
  let service: RouterAnimationsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RouterAnimationsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
