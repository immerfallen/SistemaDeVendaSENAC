import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ClienteModel } from '../../models/cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(
    private httpClient: HttpClient
  ) { }

  listarClientes() {
    return this.httpClient.get(environment.serverUrl + '/api/cliente/listar');
  }

  listarCliente(id) {
    return this.httpClient.get(environment.serverUrl + '/api/cliente/obterparaeditar/:id?Id=' + id);
  }

  inserirCliente(body: ClienteModel) {
    return this.httpClient.post(environment.serverUrl + '/api/cliente/inserir', body);
  }

  editarCliente(body: ClienteModel) {
    return this.httpClient.put(environment.serverUrl + '/api/cliente/editar/:id', body);
  }

  excluirCliente(body) {
    return this.httpClient.delete(environment.serverUrl + '/api/cliente/excluir/:id', body);
  }
}
