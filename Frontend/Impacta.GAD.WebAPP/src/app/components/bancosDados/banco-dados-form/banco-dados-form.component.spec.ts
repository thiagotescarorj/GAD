import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BancoDadosFormComponent } from './banco-dados-form.component';

describe('BancoDadosFormComponent', () => {
  let component: BancoDadosFormComponent;
  let fixture: ComponentFixture<BancoDadosFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BancoDadosFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BancoDadosFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
