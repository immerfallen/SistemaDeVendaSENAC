import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendedorEditarRoutingModule } from './vendedor-editar-routing.module';
import { VendedorEditarComponent } from './vendedor-editar.component';

@NgModule({
  declarations: [VendedorEditarComponent],
  imports: [
    CommonModule,
    VendedorEditarRoutingModule
  ]
})
export class VendedorEditarModule { }
