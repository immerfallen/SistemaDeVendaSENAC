import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioInserirRoutingModule } from './usuario-inserir-routing.module';
import { UsuarioInserirComponent } from './usuario-inserir.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [UsuarioInserirComponent],
  imports: [
    CommonModule,
    UsuarioInserirRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class UsuarioInserirModule { }
