import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { VendaModel } from '../../models/venda.model';

@Injectable({
  providedIn: 'root'
})
export class VendaService {

  constructor(
    private httpClient: HttpClient
  ) { }

  listarVendas() {
    return this.httpClient.get(environment.serverUrl + '/api/venda/listar');
  }

  listarVenda(id) {
    return this.httpClient.get(environment.serverUrl + '/api/venda/obterparaeditar/:id?Id=' + id);
  }

  inserirVenda(body: VendaModel) {
    return this.httpClient.post(environment.serverUrl + '/api/venda/inserir', body);
  }

  editarVenda(body: VendaModel) {
    return this.httpClient.put(environment.serverUrl + '/api/venda/editar/:id', body);
  }

  excluirVenda(body) {
    return this.httpClient.delete(environment.serverUrl + '/api/venda/excluir/:id', body);
  }
}
