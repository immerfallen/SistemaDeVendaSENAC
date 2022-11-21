import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { VendedorModel } from '../../models/vendedor.model';

@Injectable({
  providedIn: 'root'
})
export class VendedorService {

  constructor(
    private httpClient: HttpClient
  ) { }

  listarVendedores() {
    return this.httpClient.get(environment.serverUrl + '/api/vendedor/listar');
  }

  listarVendedor(id) {
    return this.httpClient.get(environment.serverUrl + '/api/vendedor/obterparaeditar/:id?Id=' + id);
  }

  inserirVendedor(body: VendedorModel) {
    return this.httpClient.post(environment.serverUrl + '/api/vendedor/inserir', body);
  }

  editarVendedor(body: VendedorModel) {
    return this.httpClient.put(environment.serverUrl + '/api/vendedor/editar/:id', body);
  }

  excluirVendedor(body) {
    return this.httpClient.delete(environment.serverUrl + '/api/vendedor/excluir/:id', body);
  }
}
