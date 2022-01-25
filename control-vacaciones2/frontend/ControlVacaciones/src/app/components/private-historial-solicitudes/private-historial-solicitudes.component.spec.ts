import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateHistorialSolicitudesComponent } from './private-historial-solicitudes.component';

describe('PrivateHistorialSolicitudesComponent', () => {
  let component: PrivateHistorialSolicitudesComponent;
  let fixture: ComponentFixture<PrivateHistorialSolicitudesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrivateHistorialSolicitudesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivateHistorialSolicitudesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
