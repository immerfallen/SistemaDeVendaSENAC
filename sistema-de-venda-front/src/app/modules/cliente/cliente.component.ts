import { Component, OnInit } from '@angular/core';
import { ExcluirModel } from 'src/app/core/models/excluir.model';
import { ClienteService } from 'src/app/core/services/cliente/cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent implements OnInit {
  listaClientes: any;
  excluirModel: ExcluirModel;

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
    this.excluirModel = new ExcluirModel();
    this.excluirModel.id = id;
    this.clienteService.excluirCliente(this.excluirModel, id).subscribe((resp) => {
      console.log(resp);
    });
  }

}
