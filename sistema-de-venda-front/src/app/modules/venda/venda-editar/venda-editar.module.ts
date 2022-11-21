import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaEditarRoutingModule } from './venda-editar-routing.module';
import { VendaEditarComponent } from './venda-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [VendaEditarComponent],
  imports: [
    CommonModule,
    VendaEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class VendaEditarModule { }
