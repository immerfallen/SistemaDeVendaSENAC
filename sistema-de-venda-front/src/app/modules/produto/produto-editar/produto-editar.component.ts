import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ProdutoModel } from 'src/app/core/models/produto.model';
import { ProdutoService } from 'src/app/core/services/produto/produto.service';

@Component({
  selector: 'app-produto-editar',
  templateUrl: './produto-editar.component.html',
  styleUrls: ['./produto-editar.component.scss']
})
export class ProdutoEditarComponent implements OnInit {

  produtoForm: FormGroup;
  success = false;
  error = false;
  novoProduto: ProdutoModel;
  slug: any;

  constructor(
    private fb: FormBuilder,
    private produtoService: ProdutoService,
    private activeRoute: ActivatedRoute
  ) {
    this.initializeForm();
  }

  ngOnInit() {
    this.obterProduto();
  }

  obterProduto() {
    this.slug = this.activeRoute.snapshot.params.id;

    this.produtoService.listarProduto(this.slug).subscribe((resp: ProdutoModel) => {
      this.produtoForm.controls['nome'].setValue(resp.nome);
      this.produtoForm.controls['descricao'].setValue(resp.descricao);
      this.produtoForm.controls['preco'].setValue(resp.precoUnitario);
      this.produtoForm.controls['quantidade'].setValue(resp.quantidadeEstoque);
      this.produtoForm.controls['medida'].setValue(resp.unidadeMedida);
      this.produtoForm.controls['imagem'].setValue(resp.linkFoto);
    });
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

      this.novoProduto.id = this.activeRoute.snapshot.params.id;
      this.novoProduto.nome = this.produtoForm.value.nome;
      this.novoProduto.descricao = this.produtoForm.value.descricao;
      this.novoProduto.precoUnitario = this.produtoForm.value.preco;
      this.novoProduto.quantidadeEstoque = this.produtoForm.value.quantidade;
      this.novoProduto.unidadeMedida = this.produtoForm.value.medida;
      this.novoProduto.linkFoto = this.produtoForm.value.imagem;

      this.produtoService.editarProduto(this.novoProduto).subscribe((resp) => {
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
