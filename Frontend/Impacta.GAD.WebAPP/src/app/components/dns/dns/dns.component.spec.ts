/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DNSsComponent } from './dns.component';

describe('DnsComponent', () => {
  let component: DNSsComponent;
  let fixture: ComponentFixture<DNSsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DNSsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DNSsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
