import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { INTERNAL_PATHS, INTERNAL_ROUTES, ROUTES_PATHS } from '@data/constants/routes';
import { SkeletonComponent } from '@layout/skeleton/skeleton.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: INTERNAL_ROUTES.HOME,
    pathMatch: 'full'
  },
  {
    path: INTERNAL_ROUTES.HOME,
    component: SkeletonComponent
  },
  {
    path: '**',
    redirectTo: INTERNAL_ROUTES.HOME,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
