import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaEditarRoutingModule } from './venda-editar-routing.module';
import { VendaEditarComponent } from './venda-editar.component';

@NgModule({
  declarations: [VendaEditarComponent],
  imports: [
    CommonModule,
    VendaEditarRoutingModule
  ]
})
export class VendaEditarModule { }
