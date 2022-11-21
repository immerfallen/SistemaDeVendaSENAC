import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProdutoEditarRoutingModule } from './produto-editar-routing.module';
import { ProdutoEditarComponent } from './produto-editar.component';
import { CoreModule } from 'src/app/core/core.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [ProdutoEditarComponent],
  imports: [
    CommonModule,
    ProdutoEditarRoutingModule,
    CoreModule,
    ReactiveFormsModule
  ]
})
export class ProdutoEditarModule { }
