import { ProdutoModel } from "./produto.model";

export class VendaModel {
    id: number;
    data: Date;
    vendedorId: number;
    clienteId: number;
    produtos: Array<ProdutoModel>;
}