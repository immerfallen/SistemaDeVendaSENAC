import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/core/services/produto/produto.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.scss']
})
export class ProdutoComponent implements OnInit {
  listaProduto: any;

  itensMenu = [
    { 'rotulo': 'Produtos', 'link': 'produto', 'active': true },
    { 'rotulo': 'Usuários', 'link': 'usuario', 'active': false }
  ]

  tipoUsuario = sessionStorage.getItem('tipoUsuario');

  constructor(
    private produtoService: ProdutoService
  ) { }

  ngOnInit() {
    this.listarProdutos();
  }

  listarProdutos() {
    this.produtoService.listarProdutos().subscribe((resp) => {
      this.listaProduto = resp;
    });
  }

  excluir(id) {
    const obj = {
      id: id
    }

    this.produtoService.excluirProduto(obj).subscribe((resp) => {
      console.log(resp);
    });
  }

}
