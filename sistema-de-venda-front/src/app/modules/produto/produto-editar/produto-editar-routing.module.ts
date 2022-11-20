import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoEditarComponent } from './produto-editar.component';

const routes: Routes = [
  { path: '', component: ProdutoEditarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProdutoEditarRoutingModule { }
