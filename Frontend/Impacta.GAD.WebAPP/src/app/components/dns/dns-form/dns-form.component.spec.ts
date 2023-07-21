import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DnsFormComponent } from './dns-form.component';

describe('DnsFormComponent', () => {
  let component: DnsFormComponent;
  let fixture: ComponentFixture<DnsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DnsFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DnsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
