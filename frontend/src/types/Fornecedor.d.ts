export default interface Fornecedor {
    Id: string;
    Nome: string;
    Documento: string;
    TipoFornecedor: TipoFornecedor;
    Endereco: Endereco;
    Ativo: bool;
    Produtos: Array<Produto>;
}