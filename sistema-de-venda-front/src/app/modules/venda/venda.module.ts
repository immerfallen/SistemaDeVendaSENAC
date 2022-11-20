import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaRoutingModule } from './venda-routing.module';
import { VendaComponent } from './venda.component';

@NgModule({
  declarations: [VendaComponent],
  imports: [
    CommonModule,
    VendaRoutingModule
  ]
})
export class VendaModule { }
