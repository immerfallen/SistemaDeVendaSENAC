import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaInserirRoutingModule } from './venda-inserir-routing.module';
import { VendaInserirComponent } from './venda-inserir.component';
import { CoreModule } from 'src/app/core/core.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [VendaInserirComponent],
  imports: [
    CommonModule,
    VendaInserirRoutingModule,
    CoreModule,
    SharedModule
  ]
})
export class VendaInserirModule { }
