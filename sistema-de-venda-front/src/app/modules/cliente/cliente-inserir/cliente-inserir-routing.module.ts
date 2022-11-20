import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClienteInserirComponent } from './cliente-inserir.component';

const routes: Routes = [
  { path: '', component: ClienteInserirComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteInserirRoutingModule { }
