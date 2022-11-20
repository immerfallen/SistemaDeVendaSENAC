import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendaEditarComponent } from './venda-editar.component';

const routes: Routes = [
  { path: '', component: VendaEditarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendaEditarRoutingModule { }
