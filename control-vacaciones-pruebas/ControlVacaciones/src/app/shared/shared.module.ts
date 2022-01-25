import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import * as fromComponents from './components'; // Importar componentes
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [...fromComponents.components], // Se inyectan los componenetes (Ir borrando todos los componentes que se añaden automaticamente, ya que todo eso se añade desde el index.ts)
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    ...fromComponents.components  // Se exportan los componenetes
  ]
})
export class SharedModule { }
