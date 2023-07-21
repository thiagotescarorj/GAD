import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BancoDadosEditarComponent } from './banco-dados-editar.component';

describe('BancoDadosEditarComponent', () => {
  let component: BancoDadosEditarComponent;
  let fixture: ComponentFixture<BancoDadosEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BancoDadosEditarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BancoDadosEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
