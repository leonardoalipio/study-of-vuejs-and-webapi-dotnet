using Data.Context;
using Microsoft.EntityFrameworkCore;
using Negocios.Interfaces;
using Negocios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyApiContext db) : base(db) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _Db.Produtos
                .AsNoTracking()
                .Include(x => x.Fornecedor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _Db.Produtos
                .AsNoTracking()
                .Include(x => x.Fornecedor)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}