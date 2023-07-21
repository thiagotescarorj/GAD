/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DNSService } from './dns.service';

describe('Service: Dns', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DNSService]
    });
  });

  it('should ...', inject([DNSService], (service: DNSService) => {
    expect(service).toBeTruthy();
  }));
});
