import { NgModule } from '@angular/core';
import { HistoryComponent } from './history/history.component';
import { RequestComponent } from './request/request.component';
import { SharedModule } from '@shared/shared.module';
import { PanelRoutingModule } from './panel-routing.module';
import { CommonModule } from '@angular/common';
import { ResponseRequestComponent } from './response-request/response-request.component';
import { ResponseRequestTableContentComponent } from './response-request/response-request-table-content/response-request-table-content.component';

@NgModule({
  declarations: [
    HistoryComponent,
    RequestComponent,
    ResponseRequestComponent,
    ResponseRequestTableContentComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PanelRoutingModule
  ]
})
export class PanelModule { }
