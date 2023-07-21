/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BancosDadosComponent } from './bancosDados.component';

describe('BancosDadosComponent', () => {
  let component: BancosDadosComponent;
  let fixture: ComponentFixture<BancosDadosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BancosDadosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BancosDadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
