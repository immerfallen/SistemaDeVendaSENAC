import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendaRoutingModule } from './venda-routing.module';
import { VendaComponent } from './venda.component';
import { CoreModule } from 'src/app/core/core.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [VendaComponent],
  imports: [
    CommonModule,
    VendaRoutingModule,
    CoreModule,
    SharedModule
  ]
})
export class VendaModule { }
