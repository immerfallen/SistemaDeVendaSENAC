import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UsuarioModel } from 'src/app/core/models/usuario.model';
import { UsuarioService } from 'src/app/core/services/usuario/usuario.service';

@Component({
  selector: 'app-usuario-editar',
  templateUrl: './usuario-editar.component.html',
  styleUrls: ['./usuario-editar.component.scss']
})
export class UsuarioEditarComponent implements OnInit {

  usuarioForm: FormGroup;
  success = false;
  error = false;
  novoUsuario: UsuarioModel;
  slug: any;

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private activeRoute: ActivatedRoute
  ) {
    this.initializeForm();
  }

  ngOnInit() {
    this.obterUsuario();
  }

  obterUsuario() {
    this.slug = this.activeRoute.snapshot.params.id;

    this.usuarioService.listarUsuario(this.slug).subscribe((resp: UsuarioModel) => {
      this.usuarioForm.controls['nome'].setValue(resp.nomeCompleto);
      this.usuarioForm.controls['email'].setValue(resp.email);
      this.usuarioForm.controls['senha'].setValue(resp.senha);
      this.usuarioForm.controls['tipo'].setValue(resp.papel);
    });
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

      this.novoUsuario.id = this.activeRoute.snapshot.params.id;
      this.novoUsuario.nomeCompleto = this.usuarioForm.value.nome;
      this.novoUsuario.email = this.usuarioForm.value.email;
      this.novoUsuario.senha = this.usuarioForm.value.senha;
      this.novoUsuario.papel = this.usuarioForm.value.tipo;

      this.usuarioService.editarUsuario(this.novoUsuario).subscribe((resp) => {
        if (resp) {
          this.success = true;
          
          setTimeout(() => {
            window.location.reload();
          }, 1000);
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
