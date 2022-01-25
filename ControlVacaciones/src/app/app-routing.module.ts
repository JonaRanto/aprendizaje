import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { SkeletonComponent } from '@layout/skeleton/skeleton.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: INTERNAL_ROUTES.AUTH_LOGIN,
    pathMatch: 'full'
  },
  {
    path: 'auth',
    loadChildren: () => 
    import('@modules/auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: '',
    component: SkeletonComponent,
    children: [
      {
        path: 'panel',
        loadChildren: () =>
          import('@modules/panel/panel.module').then((m) => m.PanelModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: INTERNAL_ROUTES.AUTH_LOGIN,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
