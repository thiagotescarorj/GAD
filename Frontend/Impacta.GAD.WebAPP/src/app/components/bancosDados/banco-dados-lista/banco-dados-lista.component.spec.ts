import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BancoDadosListaComponent } from './banco-dados-lista.component';

describe('BancoDadosListaComponent', () => {
  let component: BancoDadosListaComponent;
  let fixture: ComponentFixture<BancoDadosListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BancoDadosListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BancoDadosListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
