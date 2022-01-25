import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateAceptacionSolicitudesComponent } from './private-aceptacion-solicitudes.component';

describe('PrivateAceptacionSolicitudesComponent', () => {
  let component: PrivateAceptacionSolicitudesComponent;
  let fixture: ComponentFixture<PrivateAceptacionSolicitudesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrivateAceptacionSolicitudesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivateAceptacionSolicitudesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
