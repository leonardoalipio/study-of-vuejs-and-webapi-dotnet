using Api.ModelsView;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRespository;
        private readonly IMapper _mapper;

        public ProdutosController(INotificador notificador,
                                    IProdutoService produtoService,
                                    IProdutoRepository produtoRespository, 
                                    IMapper mapper) : base(notificador)
        {
            _produtoService = produtoService;
            _produtoRespository = produtoRespository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var produtos = await _produtoRespository.ObterProdutosFornecedores();

            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }
    }
}
