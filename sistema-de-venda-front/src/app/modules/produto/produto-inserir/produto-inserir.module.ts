import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProdutoInserirRoutingModule } from './produto-inserir-routing.module';
import { ProdutoInserirComponent } from './produto-inserir.component';

@NgModule({
  declarations: [ProdutoInserirComponent],
  imports: [
    CommonModule,
    ProdutoInserirRoutingModule
  ]
})
export class ProdutoInserirModule { }
