import { Component, OnInit } from '@angular/core';
import { VendedorService } from 'src/app/core/services/vendedor/vendedor.service';

@Component({
  selector: 'app-vendedor',
  templateUrl: './vendedor.component.html',
  styleUrls: ['./vendedor.component.scss']
})
export class VendedorComponent implements OnInit {
  listaVendedor: any;

  constructor(
    private vendedorService: VendedorService
  ) { }

  ngOnInit() {
    this.listarVendedores();
  }

  listarVendedores() {
    this.vendedorService.listarVendedores().subscribe((resp) => {
      this.listaVendedor = resp;
    });
  }

  excluir(id) {
    const obj = {
      id: id
    }

    this.vendedorService.excluirVendedor(obj).subscribe((resp) => {
      console.log(resp);
    });
  }

}
