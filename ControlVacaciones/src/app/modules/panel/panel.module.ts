import { NgModule } from '@angular/core';
import { HistoryComponent } from './history/history.component';
import { RequestComponent } from './request/request.component';
import { SharedModule } from '@shared/shared.module';
import { PanelRoutingModule } from './panel-routing.module';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    HistoryComponent,
    RequestComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PanelRoutingModule
  ]
})
export class PanelModule { }
