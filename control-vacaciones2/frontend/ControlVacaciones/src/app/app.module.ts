import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PublicComponent } from './components/public/public.component';
import { PublicLoginComponent } from './components/public-login/public-login.component';
import { PrivateComponent } from './components/private/private.component';
import { PrivateSidebarComponent } from './components/private-sidebar/private-sidebar.component';
import { PrivateHistorialSolicitudesComponent } from './components/private-historial-solicitudes/private-historial-solicitudes.component';
import { PrivateSolicitudVacacionesComponent } from './components/private-solicitud-vacaciones/private-solicitud-vacaciones.component';
import { PrivateAceptacionSolicitudesComponent } from './components/private-aceptacion-solicitudes/private-aceptacion-solicitudes.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input'
import { MatMomentDateModule } from '@angular/material-moment-adapter';


@NgModule({
  declarations: [
    AppComponent,
    PublicComponent,
    PublicLoginComponent,
    PrivateComponent,
    PrivateSidebarComponent,
    PrivateHistorialSolicitudesComponent,
    PrivateSolicitudVacacionesComponent,
    PrivateAceptacionSolicitudesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatInputModule,
    MatMomentDateModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
