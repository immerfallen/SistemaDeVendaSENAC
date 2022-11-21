import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioModel } from 'src/app/core/models/usuario.model';
import { UsuarioService } from 'src/app/core/services/usuario/usuario.service';

@Component({
  selector: 'app-usuario-inserir',
  templateUrl: './usuario-inserir.component.html',
  styleUrls: ['./usuario-inserir.component.scss']
})
export class UsuarioInserirComponent implements OnInit {

  usuarioForm: FormGroup;
  success = false;
  error = false;
  novoUsuario: UsuarioModel;

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService
  ) {
    this.initializeForm();
  }

  ngOnInit() {
  }

  initializeForm() {
    this.usuarioForm = this.fb.group({
      'nome': ['', Validators.required],
      'email': ['', Validators.required],
      'senha': ['', Validators.required],
      'tipo': ['', Validators.required]
    });
  }

  enviar() {
    if (this.usuarioForm.valid) {
      this.error = false;
      this.success = false;

      this.novoUsuario = new UsuarioModel();

      this.novoUsuario.nomeCompleto = this.usuarioForm.value.nome;
      this.novoUsuario.email = this.usuarioForm.value.email;
      this.novoUsuario.senha = this.usuarioForm.value.senha;
      this.novoUsuario.papel = this.usuarioForm.value.tipo;

      this.usuarioService.inserirUsuario(this.novoUsuario).subscribe((resp) => {
        if (resp) {
          this.success = true;
          this.usuarioForm.reset(this.usuarioForm.value);
        } else {
          this.error = false;
        }
      });
    }
  }

  fechar() {
    this.error = false;
    this.success = false;
  }

}
