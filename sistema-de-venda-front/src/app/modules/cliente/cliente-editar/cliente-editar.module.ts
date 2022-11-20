import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteEditarRoutingModule } from './cliente-editar-routing.module';
import { ClienteEditarComponent } from './cliente-editar.component';

@NgModule({
  declarations: [ClienteEditarComponent],
  imports: [
    CommonModule,
    ClienteEditarRoutingModule
  ]
})
export class ClienteEditarModule { }
