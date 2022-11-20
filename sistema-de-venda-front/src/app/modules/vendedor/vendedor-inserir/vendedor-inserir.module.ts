import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendedorInserirRoutingModule } from './vendedor-inserir-routing.module';
import { VendedorInserirComponent } from './vendedor-inserir.component';

@NgModule({
  declarations: [VendedorInserirComponent],
  imports: [
    CommonModule,
    VendedorInserirRoutingModule
  ]
})
export class VendedorInserirModule { }
