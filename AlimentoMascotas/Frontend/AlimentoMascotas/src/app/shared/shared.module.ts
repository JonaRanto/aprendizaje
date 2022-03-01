import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as fromComponents from './components';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    ...fromComponents.components,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
  ],
  exports: [
    ...fromComponents.components,
  ],
})
export class SharedModule { }
