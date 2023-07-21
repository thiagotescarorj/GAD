import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChamadoListaComponent } from './chamado-lista.component';

describe('ChamadoListaComponent', () => {
  let component: ChamadoListaComponent;
  let fixture: ComponentFixture<ChamadoListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChamadoListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChamadoListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
