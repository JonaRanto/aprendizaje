import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkeletonComponent } from '@layout/skeleton/skeleton.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/panel/user',  // Si no se pone ninguna ruta, se redirige a /panel/user
    pathMatch: 'full'     // La redirección se hace solo a la ubicacion indicada de forma exacta.
  },
  {
    path: 'panel',
    component: SkeletonComponent,
    children: [
      {
        path: 'user',
        loadChildren: () =>   // Sistema lazyloader ayuda a que la información no ser cargue toda de golpe, en este caso angular proporciona el metodo loadChildren que utiliza esta funcion
          import('@modules/user/user.module').then((m) => m.UserModule)
      },
      {
        path: '**',                 // Utilizar este path siempre como ultimo path al final de las rutas alternas, para que solo se ejecute luego de hacer todas las búsquedas de los paths anteriores
        redirectTo: '/panel/user',  // Si se encuentra cualquier ruta que no exista dentro de la app, se redirige a /panel/user
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '**',                 // Utilizar este path siempre como ultimo path al final de las rutas alternas, para que solo se ejecute luego de hacer todas las búsquedas de los paths anteriores
    redirectTo: '/panel/user',  // Si se encuentra cualquier ruta que no exista dentro de la app, se redirige a /panel/user
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
