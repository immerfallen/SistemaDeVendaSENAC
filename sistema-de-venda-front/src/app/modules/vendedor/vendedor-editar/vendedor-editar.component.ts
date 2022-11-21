import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { VendedorModel } from 'src/app/core/models/vendedor.model';
import { VendedorService } from 'src/app/core/services/vendedor/vendedor.service';

@Component({
  selector: 'app-vendedor-editar',
  templateUrl: './vendedor-editar.component.html',
  styleUrls: ['./vendedor-editar.component.scss']
})
export class VendedorEditarComponent implements OnInit {

  vendedorForm: FormGroup;
  success = false;
  error = false;
  novoVendedor: VendedorModel;
  slug: any;

  itensMenu = [
    { 'rotulo': 'Vendas', 'link': 'venda', 'active': false },
    { 'rotulo': 'Vendedores', 'link': 'vendedor', 'active': true },
    { 'rotulo': 'Clientes', 'link': 'cliente', 'active': false }
  ]

  tipoUsuario = sessionStorage.getItem('tipoUsuario');

  constructor(
    private fb: FormBuilder,
    private vendedorService: VendedorService,
    private activeRoute: ActivatedRoute
  ) {
    this.initializeForm();
  }

  ngOnInit() {
    this.obterVendedor();
  }

  obterVendedor() {
    this.slug = this.activeRoute.snapshot.params.id;

    this.vendedorService.listarVendedor(this.slug).subscribe((resp: VendedorModel) => {
      this.vendedorForm.controls['nome'].setValue(resp.nome);
      this.vendedorForm.controls['email'].setValue(resp.email);
    });
  }

  initializeForm() {
    this.vendedorForm = this.fb.group({
      'nome': ['', Validators.required],
      'email': ['', Validators.required]
    });
  }

  enviar() {
    if (this.vendedorForm.valid) {
      this.error = false;
      this.success = false;

      this.novoVendedor = new VendedorModel();

      this.novoVendedor.id = this.activeRoute.snapshot.params.id;
      this.novoVendedor.nome = this.vendedorForm.value.nome;
      this.novoVendedor.email = this.vendedorForm.value.email;
      this.novoVendedor.senha = '1234';

      this.vendedorService.editarVendedor(this.novoVendedor).subscribe((resp) => {
        if (resp) {
          this.success = true;
          this.vendedorForm.reset(this.vendedorForm.value);

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
