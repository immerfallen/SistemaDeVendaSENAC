import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClienteInserirRoutingModule } from './cliente-inserir-routing.module';
import { ClienteInserirComponent } from './cliente-inserir.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [ClienteInserirComponent],
  imports: [
    CommonModule,
    ClienteInserirRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class ClienteInserirModule { }
