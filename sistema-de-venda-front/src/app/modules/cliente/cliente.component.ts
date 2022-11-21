import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/core/services/cliente/cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  listaClientes: any;

  itensMenu = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': false },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': true }
  ]

  itensMenuGer = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': false },
    { 'rotulo': 'Vendedores', 'link': 'vendedor', 'active': false },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': true }
  ]

  tipoUsuario = sessionStorage.getItem('tipoUsuario');

  constructor(
    private clienteService: ClienteService
  ) { }

  ngOnInit() {
    this.listarClientes();
  }

  listarClientes() {
    this.clienteService.listarClientes().subscribe((resp) => {
      this.listaClientes = resp;
    });
  }

  excluir(id) {
    const obj = {
      id: id
    }

    this.clienteService.excluirCliente(obj).subscribe((resp) => {
      console.log(resp);
    });
  }

}
