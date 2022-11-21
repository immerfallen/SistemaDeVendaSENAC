import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioEditarRoutingModule } from './usuario-editar-routing.module';
import { UsuarioEditarComponent } from './usuario-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [UsuarioEditarComponent],
  imports: [
    CommonModule,
    UsuarioEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class UsuarioEditarModule { }
