import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProdutoModel } from 'src/app/core/models/produto.model';
import { ProdutoService } from 'src/app/core/services/produto/produto.service';

@Component({
  selector: 'app-produto-inserir',
  templateUrl: './produto-inserir.component.html',
  styleUrls: ['./produto-inserir.component.scss']
})
export class ProdutoInserirComponent implements OnInit {

  produtoForm: FormGroup;
  success = false;
  error = false;
  novoProduto: ProdutoModel;

  itensMenu = [
    { 'rotulo': 'Produtos', 'link': 'produto', 'active': true },
    { 'rotulo': 'Usuários', 'link': 'usuario', 'active': false }
  ]

  tipoUsuario = sessionStorage.getItem('tipoUsuario');

  constructor(
    private fb: FormBuilder,
    private produtoService: ProdutoService
  ) {
    this.initializeForm();
  }

  ngOnInit() {
  }

  initializeForm() {
    this.produtoForm = this.fb.group({
      'nome': ['', Validators.required],
      'descricao': ['', Validators.required],
      'preco': ['', Validators.required],
      'quantidade': ['', Validators.required],
      'medida': ['', Validators.required],
      'imagem': ['', Validators.required]
    });
  }

  enviar() {
    if (this.produtoForm.valid) {
      this.error = false;
      this.success = false;

      this.novoProduto = new ProdutoModel();

      this.novoProduto.nome = this.produtoForm.value.nome;
      this.novoProduto.descricao = this.produtoForm.value.descricao;
      this.novoProduto.precoUnitario = this.produtoForm.value.preco;
      this.novoProduto.quantidadeEstoque = this.produtoForm.value.quantidade;
      this.novoProduto.unidadeMedida = this.produtoForm.value.medida;
      this.novoProduto.linkFoto = this.produtoForm.value.imagem;

      this.produtoService.inserirProduto(this.novoProduto).subscribe((resp) => {
        if (resp) {
          this.success = true;
          this.produtoForm.reset(this.produtoForm.value);
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
