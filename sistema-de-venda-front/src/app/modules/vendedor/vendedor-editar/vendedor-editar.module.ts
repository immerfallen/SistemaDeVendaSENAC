import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendedorEditarRoutingModule } from './vendedor-editar-routing.module';
import { VendedorEditarComponent } from './vendedor-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [VendedorEditarComponent],
  imports: [
    CommonModule,
    VendedorEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class VendedorEditarModule { }
