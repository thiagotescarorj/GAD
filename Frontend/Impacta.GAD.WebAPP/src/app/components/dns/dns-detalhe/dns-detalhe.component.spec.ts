import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DnsDetalheComponent } from './dns-detalhe.component';

describe('DnsDetalheComponent', () => {
  let component: DnsDetalheComponent;
  let fixture: ComponentFixture<DnsDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DnsDetalheComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DnsDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
