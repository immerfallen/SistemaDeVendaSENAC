import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProdutoEditarRoutingModule } from './produto-editar-routing.module';
import { ProdutoEditarComponent } from './produto-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [ProdutoEditarComponent],
  imports: [
    CommonModule,
    ProdutoEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class ProdutoEditarModule { }
