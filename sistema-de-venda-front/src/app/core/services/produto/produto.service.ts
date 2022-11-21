import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ProdutoModel } from '../../models/produto.model';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  constructor(
    private httpClient: HttpClient
  ) { }

  listarProdutos() {
    return this.httpClient.get(environment.serverUrl + '/api/produto/listar');
  }

  listarProduto(id) {
    return this.httpClient.get(environment.serverUrl + '/api/produto/obterparaeditar/:id?Id=' + id);
  }

  inserirProduto(body: ProdutoModel) {
    return this.httpClient.post(environment.serverUrl + '/api/produto/inserir', body);
  }

  editarProduto(body: ProdutoModel) {
    return this.httpClient.put(environment.serverUrl + '/api/produto/editar/:id', body);
  }

  excluirProduto(body) {
    return this.httpClient.delete(environment.serverUrl + '/api/produto/excluir/:id', body);
  }
}
