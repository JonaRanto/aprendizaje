import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as fromComponents from './components';
import { ProductsComponent } from './components/products/products.component';

@NgModule({
  declarations: [
    ...fromComponents.components,
    ProductsComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    ...fromComponents.components
  ],
})
export class SharedModule { }
