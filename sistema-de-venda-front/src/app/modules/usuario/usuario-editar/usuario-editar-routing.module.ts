import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioEditarComponent } from './usuario-editar.component';

const routes: Routes = [
  { path: '', component: UsuarioEditarComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioEditarRoutingModule { }
