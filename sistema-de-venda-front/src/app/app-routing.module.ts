import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './modules/login/login.component';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: 'cliente', loadChildren: () => import('./modules/cliente/cliente.module').then(m => m.ClienteModule) },
  { path: 'cliente/inserir', loadChildren: () => import('./modules/cliente/cliente-inserir/cliente-inserir.module').then(m => m.ClienteInserirModule) },
  { path: 'cliente/editar', loadChildren: () => import('./modules/cliente/cliente-editar/cliente-editar.module').then(m => m.ClienteEditarModule) },
  { path: 'produto', loadChildren: () => import('./modules/produto/produto.module').then(m => m.ProdutoModule) },
  { path: 'produto/inserir', loadChildren: () => import('./modules/produto/produto-inserir/produto-inserir.module').then(m => m.ProdutoInserirModule) },
  { path: 'produto/editar', loadChildren: () => import('./modules/produto/produto-editar/produto-editar.module').then(m => m.ProdutoEditarModule) },
  { path: 'usuario', loadChildren: () => import('./modules/usuario/usuario.module').then(m => m.UsuarioModule) },
  { path: 'usuario/inserir', loadChildren: () => import('./modules/usuario/usuario-inserir/usuario-inserir.module').then(m => m.UsuarioInserirModule) },
  { path: 'usuario/editar', loadChildren: () => import('./modules/usuario/usuario-editar/usuario-editar.module').then(m => m.UsuarioEditarModule) },
  { path: 'venda', loadChildren: () => import('./modules/venda/venda.module').then(m => m.VendaModule) },
  { path: 'venda/inserir', loadChildren: () => import('./modules/venda/venda-inserir/venda-inserir.module').then(m => m.VendaInserirModule) },
  { path: 'venda/editar', loadChildren: () => import('./modules/venda/venda-editar/venda-editar.module').then(m => m.VendaEditarModule) },
  { path: 'vendedor', loadChildren: () => import('./modules/vendedor/vendedor.module').then(m => m.VendedorModule) },
  { path: 'vendedor/inserir', loadChildren: () => import('./modules/vendedor/vendedor-inserir/vendedor-inserir.module').then(m => m.VendedorInserirModule) },
  { path: 'vendedor/editar', loadChildren: () => import('./modules/vendedor/vendedor-editar/vendedor-editar.module').then(m => m.VendedorEditarModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
