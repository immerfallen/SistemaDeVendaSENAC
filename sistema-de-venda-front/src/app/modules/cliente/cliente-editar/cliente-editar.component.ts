import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ClienteModel } from 'src/app/core/models/cliente.model';
import { ClienteService } from 'src/app/core/services/cliente/cliente.service';

@Component({
  selector: 'app-cliente-editar',
  templateUrl: './cliente-editar.component.html',
  styleUrls: ['./cliente-editar.component.scss']
})
export class ClienteEditarComponent implements OnInit {

  clienteForm: FormGroup;
  success = false;
  error = false;
  novoCliente: ClienteModel;
  slug: any;

  constructor(
    private fb: FormBuilder,
    private clienteService: ClienteService,
    private activeRoute: ActivatedRoute
  ) {
    this.initializeForm();
  }

  ngOnInit() {
    this.obterCliente();
  }

  obterCliente() {
    this.slug = this.activeRoute.snapshot.params.id;

    this.clienteService.listarCliente(this.slug).subscribe((resp: ClienteModel) => {
      this.clienteForm.controls['nome'].setValue(resp.nome);
      this.clienteForm.controls['cpf'].setValue(resp.cpF_CNPJ);
      this.clienteForm.controls['email'].setValue(resp.email);
    });
  }

  initializeForm() {
    this.clienteForm = this.fb.group({
      'nome': ['', Validators.required],
      'cpf': ['', Validators.required],
      'email': ['', Validators.required]
    });
  }

  enviar() {
    if (this.clienteForm.valid) {
      this.error = false;
      this.success = false;

      this.novoCliente = new ClienteModel();

      this.novoCliente.id = this.activeRoute.snapshot.params.id;
      this.novoCliente.nome = this.clienteForm.value.nome;
      this.novoCliente.cpF_CNPJ = this.clienteForm.value.cpf;
      this.novoCliente.email = this.clienteForm.value.email;
      this.novoCliente.senha = '1234';

      this.clienteService.editarCliente(this.novoCliente).subscribe((resp) => {
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
