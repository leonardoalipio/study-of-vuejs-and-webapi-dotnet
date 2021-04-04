using Negocios.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocios.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedor(Guid id);
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);

        Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresProdutosEndereco();

    }
}