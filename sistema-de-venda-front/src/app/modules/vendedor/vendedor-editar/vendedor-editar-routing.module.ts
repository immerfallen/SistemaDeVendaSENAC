import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendedorEditarComponent } from './vendedor-editar.component';

const routes: Routes = [
  { path: '', component: VendedorEditarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendedorEditarRoutingModule { }
