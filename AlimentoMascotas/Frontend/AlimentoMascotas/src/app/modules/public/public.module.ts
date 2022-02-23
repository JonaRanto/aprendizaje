import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { PublicRouteModule } from './public-routing.module';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  declarations: [
    MainComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PublicRouteModule
  ]
})
export class PublicModule { }
