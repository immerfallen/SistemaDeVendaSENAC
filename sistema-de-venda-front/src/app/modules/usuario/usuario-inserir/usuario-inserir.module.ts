import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioInserirRoutingModule } from './usuario-inserir-routing.module';
import { UsuarioInserirComponent } from './usuario-inserir.component';

@NgModule({
  declarations: [UsuarioInserirComponent],
  imports: [
    CommonModule,
    UsuarioInserirRoutingModule
  ]
})
export class UsuarioInserirModule { }
