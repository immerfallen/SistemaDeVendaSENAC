import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioInserirRoutingModule } from './usuario-inserir-routing.module';
import { UsuarioInserirComponent } from './usuario-inserir.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [UsuarioInserirComponent],
  imports: [
    CommonModule,
    UsuarioInserirRoutingModule,
    CoreModule,
    ReactiveFormsModule
  ]
})
export class UsuarioInserirModule { }
