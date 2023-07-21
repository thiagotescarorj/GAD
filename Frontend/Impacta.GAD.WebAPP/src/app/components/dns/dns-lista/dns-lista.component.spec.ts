import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DnsListaComponent } from './dns-lista.component';

describe('DnsListaComponent', () => {
  let component: DnsListaComponent;
  let fixture: ComponentFixture<DnsListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DnsListaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DnsListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
