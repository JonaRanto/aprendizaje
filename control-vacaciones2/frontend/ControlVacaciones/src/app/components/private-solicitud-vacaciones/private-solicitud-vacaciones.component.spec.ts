import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivateSolicitudVacacionesComponent } from './private-solicitud-vacaciones.component';

describe('PrivateSolicitudVacacionesComponent', () => {
  let component: PrivateSolicitudVacacionesComponent;
  let fixture: ComponentFixture<PrivateSolicitudVacacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrivateSolicitudVacacionesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivateSolicitudVacacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
