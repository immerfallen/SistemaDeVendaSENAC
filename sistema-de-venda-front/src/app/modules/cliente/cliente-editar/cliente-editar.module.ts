import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteEditarRoutingModule } from './cliente-editar-routing.module';
import { ClienteEditarComponent } from './cliente-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [ClienteEditarComponent],
  imports: [
    CommonModule,
    ClienteEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class ClienteEditarModule { }
