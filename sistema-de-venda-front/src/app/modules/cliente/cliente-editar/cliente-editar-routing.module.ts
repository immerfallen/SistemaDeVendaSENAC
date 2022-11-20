import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClienteEditarComponent } from './cliente-editar.component';

const routes: Routes = [
  { path: '', component: ClienteEditarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteEditarRoutingModule { }
