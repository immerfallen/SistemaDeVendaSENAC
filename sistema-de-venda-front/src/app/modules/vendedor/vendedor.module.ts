import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendedorRoutingModule } from './vendedor-routing.module';
import { VendedorComponent } from './vendedor.component';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  declarations: [VendedorComponent],
  imports: [
    CommonModule,
    VendedorRoutingModule,
    CoreModule
  ]
})
export class VendedorModule { }
