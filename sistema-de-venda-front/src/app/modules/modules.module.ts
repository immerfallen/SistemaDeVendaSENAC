import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteModule } from './cliente/cliente.module';
import { LoginModule } from './login/login.module';
import { ProdutoModule } from './produto/produto.module';
import { UsuarioModule } from './usuario/usuario.module';
import { VendaModule } from './venda/venda.module';
import { VendedorModule } from './vendedor/vendedor.module';
import { ClienteInserirModule } from './cliente/cliente-inserir/cliente-inserir.module';
import { ClienteEditarModule } from './cliente/cliente-editar/cliente-editar.module';
import { ProdutoInserirModule } from './produto/produto-inserir/produto-inserir.module';
import { ProdutoEditarModule } from './produto/produto-editar/produto-editar.module';
import { UsuarioInserirModule } from './usuario/usuario-inserir/usuario-inserir.module';
import { UsuarioEditarModule } from './usuario/usuario-editar/usuario-editar.module';
import { VendaInserirModule } from './venda/venda-inserir/venda-inserir.module';
import { VendaEditarModule } from './venda/venda-editar/venda-editar.module';
import { VendedorInserirModule } from './vendedor/vendedor-inserir/vendedor-inserir.module';
import { VendedorEditarModule } from './vendedor/vendedor-editar/vendedor-editar.module';

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        ClienteModule,
        ClienteInserirModule,
        ClienteEditarModule,
        LoginModule,
        ProdutoModule,
        ProdutoInserirModule,
        ProdutoEditarModule,
        UsuarioModule,
        UsuarioInserirModule,
        UsuarioEditarModule,
        VendaModule,
        VendaInserirModule,
        VendaEditarModule,
        VendedorModule,
        VendedorInserirModule,
        VendedorEditarModule
    ]
})
export class ModulesModule { }
