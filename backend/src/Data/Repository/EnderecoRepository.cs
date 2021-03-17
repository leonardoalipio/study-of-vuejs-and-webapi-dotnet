using Data.Context;
using Microsoft.EntityFrameworkCore;
using Negocios.Interfaces;
using Negocios.Models;
using System;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MyApiContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await _Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.FornecedorId == fornecedorId);
        }
    }
}