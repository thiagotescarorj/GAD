import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DnsEditarComponent } from './dns-editar.component';

describe('DnsEditarComponent', () => {
  let component: DnsEditarComponent;
  let fixture: ComponentFixture<DnsEditarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DnsEditarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DnsEditarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
