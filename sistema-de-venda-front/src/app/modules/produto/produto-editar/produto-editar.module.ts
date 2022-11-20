import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProdutoEditarRoutingModule } from './produto-editar-routing.module';
import { ProdutoEditarComponent } from './produto-editar.component';

@NgModule({
  declarations: [ProdutoEditarComponent],
  imports: [
    CommonModule,
    ProdutoEditarRoutingModule
  ]
})
export class ProdutoEditarModule { }
