import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaInserirRoutingModule } from './venda-inserir-routing.module';
import { VendaInserirComponent } from './venda-inserir.component';

@NgModule({
  declarations: [VendaInserirComponent],
  imports: [
    CommonModule,
    VendaInserirRoutingModule
  ]
})
export class VendaInserirModule { }
