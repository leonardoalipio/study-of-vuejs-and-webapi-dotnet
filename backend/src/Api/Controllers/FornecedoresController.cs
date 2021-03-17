using Api.ModelsView;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Negocios.Interfaces;
using Negocios.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository, 
                                    IMapper mapper, 
                                    IFornecedorService fornecedorService)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [HttpGet("obter-todos")]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
        {
            var fornecedores = await _fornecedorRepository.ObterTodos();

            var resultMap = _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);

            return Ok(resultMap);
        }

        [HttpGet("obter-todos-fornecedores-produtos-endereco")]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodosFornecedoresProdutosEndereco()
        {
            var fornecedores = await _fornecedorRepository.ObterTodosFornecedoresProdutosEndereco();

            var resultMap = _mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores);

            return Ok(resultMap);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterFornecedorProdutosEndereco(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            var fornecedorProdutosEndereco = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            return _mapper.Map<FornecedorViewModel>(fornecedorProdutosEndereco);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> Adicionar(FornecedorViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var fornecedor = _mapper.Map<Fornecedor>(model);
            await _fornecedorService.Adicionar(fornecedor);

            return Ok();
        }
    }
}
