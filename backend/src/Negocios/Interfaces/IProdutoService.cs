using System;
using System.Threading.Tasks;
using Negocios.Models;

namespace Negocios.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}