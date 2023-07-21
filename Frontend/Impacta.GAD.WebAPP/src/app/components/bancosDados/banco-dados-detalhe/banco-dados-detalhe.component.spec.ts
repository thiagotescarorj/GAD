import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BancoDadosDetalheComponent } from './banco-dados-detalhe.component';

describe('BancoDadosDetalheComponent', () => {
  let component: BancoDadosDetalheComponent;
  let fixture: ComponentFixture<BancoDadosDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BancoDadosDetalheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BancoDadosDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
