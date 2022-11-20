import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteInserirRoutingModule } from './cliente-inserir-routing.module';
import { ClienteInserirComponent } from './cliente-inserir.component';

@NgModule({
  declarations: [ClienteInserirComponent],
  imports: [
    CommonModule,
    ClienteInserirRoutingModule
  ]
})
export class ClienteInserirModule { }
