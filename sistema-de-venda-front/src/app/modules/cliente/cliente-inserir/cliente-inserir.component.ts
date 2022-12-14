import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteModel } from 'src/app/core/models/cliente.model';
import { ClienteService } from 'src/app/core/services/cliente/cliente.service';

@Component({
  selector: 'app-cliente-inserir',
  templateUrl: './cliente-inserir.component.html',
  styleUrls: ['./cliente-inserir.component.scss']
})
export class ClienteInserirComponent implements OnInit {

  clienteForm: FormGroup;
  success = false;
  error = false;
  novoCliente: ClienteModel;

  itensMenu = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': false },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': true }
  ]

  itensMenuGer = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': false },
    { 'rotulo': 'Vendedores', 'link': 'vendedor', 'active': false },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': true }
  ]

  tipoUsuario = sessionStorage.getItem('tipoUsuario');

  constructor(
    private fb: FormBuilder,
    private clienteService: ClienteService
  ) {
    this.initializeForm();
  }

  ngOnInit() {
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

      this.novoCliente.nome = this.clienteForm.value.nome;
      this.novoCliente.cpF_CNPJ = this.clienteForm.value.cpf;
      this.novoCliente.email = this.clienteForm.value.email;

      this.clienteService.inserirCliente(this.novoCliente).subscribe((resp) => {
        if (resp) {
          this.success = true;
          this.clienteForm.reset(this.clienteForm.value);
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
