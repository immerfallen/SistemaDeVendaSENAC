import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/core/services/usuario/usuario.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent implements OnInit {

  listaUsuarios: any;

  constructor(
    private usuarioService: UsuarioService
  ) { }

  ngOnInit() {
    this.listarUsuarios();
  }

  listarUsuarios() {
    this.usuarioService.listarUsuarios().subscribe((resp) => {
      console.log(resp);
      this.listaUsuarios = resp;
    });
  }

  excluir(id) {
    const obj = {
      id: id
    }

    this.usuarioService.excluirUsuario(obj).subscribe((resp) => {
      console.log(resp);
    });
  }

}
