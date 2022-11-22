import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/core/services/cliente/cliente.service';
import { ProdutoService } from 'src/app/core/services/produto/produto.service';

@Component({
  selector: 'app-venda-editar',
  templateUrl: './venda-editar.component.html',
  styleUrls: ['./venda-editar.component.scss']
})
export class VendaEditarComponent implements OnInit {

  listaClientes: any;
  listaProduto: any;

  itensMenu = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': true },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': false }
  ]

  itensMenuGer = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': true },
    { 'rotulo': 'Vendedores', 'link': 'vendedor', 'active': false },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': false }
  ]

  tipoUsuario = sessionStorage.getItem('tipoUsuario');

  constructor(
    private clienteService: ClienteService,
    private produtoService: ProdutoService
  ) { }

  ngOnInit() {
    this.listarClientes();
    this.listarProdutos();
  }

  listarClientes() {
    this.clienteService.listarClientes().subscribe((resp) => {
      this.listaClientes = resp;
    });
  }

  listarProdutos() {
    this.produtoService.listarProdutos().subscribe((resp) => {
      this.listaProduto = resp;
    });
  }

}
