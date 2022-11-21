import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaInserirRoutingModule } from './venda-inserir-routing.module';
import { VendaInserirComponent } from './venda-inserir.component';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  declarations: [VendaInserirComponent],
  imports: [
    CommonModule,
    VendaInserirRoutingModule,
    CoreModule
  ]
})
export class VendaInserirModule { }
