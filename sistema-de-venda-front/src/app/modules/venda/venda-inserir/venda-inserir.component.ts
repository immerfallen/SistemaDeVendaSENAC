import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-venda-inserir',
  templateUrl: './venda-inserir.component.html',
  styleUrls: ['./venda-inserir.component.scss']
})
export class VendaInserirComponent implements OnInit {

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

  constructor() { }

  ngOnInit() {
  }

}
