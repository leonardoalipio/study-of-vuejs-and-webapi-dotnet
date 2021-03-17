using System;
using System.Threading.Tasks;
using Negocios.Models;

namespace Negocios.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {         
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}