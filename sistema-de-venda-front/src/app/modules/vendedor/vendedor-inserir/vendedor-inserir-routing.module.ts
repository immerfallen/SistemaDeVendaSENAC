import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendedorInserirComponent } from './vendedor-inserir.component';

const routes: Routes = [
  { path: '', component: VendedorInserirComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendedorInserirRoutingModule { }
