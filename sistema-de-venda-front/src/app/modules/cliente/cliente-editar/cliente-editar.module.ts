import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteEditarRoutingModule } from './cliente-editar-routing.module';
import { ClienteEditarComponent } from './cliente-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ClienteEditarComponent],
  imports: [
    CommonModule,
    ClienteEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule
  ]
})
export class ClienteEditarModule { }
