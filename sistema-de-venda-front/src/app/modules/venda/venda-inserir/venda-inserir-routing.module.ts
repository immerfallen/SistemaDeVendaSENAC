import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VendaInserirComponent } from './venda-inserir.component';

const routes: Routes = [
  { path: '', component: VendaInserirComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendaInserirRoutingModule { }
