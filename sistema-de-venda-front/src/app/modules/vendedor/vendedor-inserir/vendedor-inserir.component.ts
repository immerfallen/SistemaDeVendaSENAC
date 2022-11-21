import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VendedorModel } from 'src/app/core/models/vendedor.model';
import { VendedorService } from 'src/app/core/services/vendedor/vendedor.service';

@Component({
  selector: 'app-vendedor-inserir',
  templateUrl: './vendedor-inserir.component.html',
  styleUrls: ['./vendedor-inserir.component.scss']
})
export class VendedorInserirComponent implements OnInit {

  vendedorForm: FormGroup;
  success = false;
  error = false;
  novoVendedor: VendedorModel;

  constructor(
    private fb: FormBuilder,
    private vendedorService: VendedorService
  ) {
    this.initializeForm();
  }

  ngOnInit() {
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

      this.novoVendedor.nome = this.vendedorForm.value.nome;
      this.novoVendedor.email = this.vendedorForm.value.email;

      this.vendedorService.inserirVendedor(this.novoVendedor).subscribe((resp) => {
        if (resp) {
          this.success = true;
          this.vendedorForm.reset(this.vendedorForm.value);
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
