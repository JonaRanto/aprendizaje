import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { INTERNAL_PATHS } from '@data/constants';
import { PublicSkeletonComponent } from './layouts';

const routes: Routes = [
  { 
    path: '',
    component: PublicSkeletonComponent,
    children: [
      { 
        path: '',
        loadChildren: () =>
        import('@modules/public/public.module').then((m) => m.PublicModule)
      }
    ]
  },
  {
    path: INTERNAL_PATHS.AUTH_DEFAULT,
    loadChildren: () =>
    import('@modules/auth/auth.module').then((m) => m.AuthModule)
  },
  {
    path: INTERNAL_PATHS.PRIVATE_DEFAULT,
    loadChildren: () =>
    import('@modules/private/private.module').then((m) => m.PrivateModule)
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full',
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
