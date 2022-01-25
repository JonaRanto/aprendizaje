import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublicComponent } from './components/public/public.component';
import { PublicLoginComponent } from './components/public-login/public-login.component';
import { PrivateComponent } from './components/private/private.component';
import { PrivateHistorialSolicitudesComponent } from './components/private-historial-solicitudes/private-historial-solicitudes.component';
import { PrivateSolicitudVacacionesComponent } from './components/private-solicitud-vacaciones/private-solicitud-vacaciones.component';
import { PrivateAceptacionSolicitudesComponent } from './components/private-aceptacion-solicitudes/private-aceptacion-solicitudes.component';

const routes: Routes = [
  {
    path: '', component: PublicComponent, children: [
      { path: '', component: PublicLoginComponent },
    ]
  },
  {
    path: 'private', component: PrivateComponent, children: [
      { path: 'historial-solicitudes', component: PrivateHistorialSolicitudesComponent},
      { path: 'solicitud-vacaciones', component: PrivateSolicitudVacacionesComponent},
      { path: 'aceptacion-solicitudes', component: PrivateAceptacionSolicitudesComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
