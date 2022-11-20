import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoInserirComponent } from './produto-inserir.component';

const routes: Routes = [
  { path: '', component: ProdutoInserirComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProdutoInserirRoutingModule { }
