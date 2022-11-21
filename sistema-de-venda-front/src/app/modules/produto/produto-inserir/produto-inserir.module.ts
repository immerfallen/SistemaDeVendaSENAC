import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProdutoInserirRoutingModule } from './produto-inserir-routing.module';
import { ProdutoInserirComponent } from './produto-inserir.component';
import { CoreModule } from 'src/app/core/core.module';

@NgModule({
  declarations: [ProdutoInserirComponent],
  imports: [
    CommonModule,
    ProdutoInserirRoutingModule,
    CoreModule
  ]
})
export class ProdutoInserirModule { }
