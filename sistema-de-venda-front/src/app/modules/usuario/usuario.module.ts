import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { UsuarioComponent } from './usuario.component';
import { CoreModule } from 'src/app/core/core.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [UsuarioComponent],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    CoreModule,
    SharedModule
  ]
})
export class UsuarioModule { }
