import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendedorInserirRoutingModule } from './vendedor-inserir-routing.module';
import { VendedorInserirComponent } from './vendedor-inserir.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [VendedorInserirComponent],
  imports: [
    CommonModule,
    VendedorInserirRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class VendedorInserirModule { }
