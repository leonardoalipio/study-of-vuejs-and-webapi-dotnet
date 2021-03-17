using Api.ModelsView;
using AutoMapper;
using Negocios.Models;
using System.Linq;

namespace Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();

            CreateMap<ProdutoViewModel, Produto>();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();


            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }
    }
}
