using Data.Context;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Negocios.Interfaces;
using Negocios.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MyApiContext db) : base(db) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _Db.Fornecedores
                .AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _Db.Fornecedores
                .AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Fornecedor>> ObterTodosFornecedoresProdutosEndereco()
        {
            return await _Db.Fornecedores
                .AsNoTracking()
                .Include(x => x.Endereco)
                .Include(x => x.Produtos)
                .ToListAsync();
        }
    }
}