import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UsuarioModel } from '../../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(
    private httpClient: HttpClient
  ) { }

  listarUsuarios() {
    return this.httpClient.get(environment.serverUrl + '/api/usuario/listar');
  }

  listarUsuario(id) {
    return this.httpClient.get(environment.serverUrl + '/api/usuario/obterparaeditar/:id?Id=' + id);
  }

  inserirUsuario(body: UsuarioModel) {
    return this.httpClient.post(environment.serverUrl + '/api/usuario/inserir', body);
  }

  editarUsuario(body: UsuarioModel) {
    return this.httpClient.put(environment.serverUrl + '/api/usuario/editar/:id', body);
  }

  excluirUsuario(body) {
    return this.httpClient.delete(environment.serverUrl + '/api/usuario/excluir/:id', body);
  }
}
