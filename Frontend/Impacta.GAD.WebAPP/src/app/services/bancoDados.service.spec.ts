/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BancoDadosService } from './bancoDados.service';

describe('Service: BancoDados', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BancoDadosService]
    });
  });

  it('should ...', inject([BancoDadosService], (service: BancoDadosService) => {
    expect(service).toBeTruthy();
  }));
});
