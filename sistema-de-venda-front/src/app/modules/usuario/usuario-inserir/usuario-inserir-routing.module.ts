import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioInserirComponent } from './usuario-inserir.component';

const routes: Routes = [
  { path: '', component: UsuarioInserirComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioInserirRoutingModule { }
