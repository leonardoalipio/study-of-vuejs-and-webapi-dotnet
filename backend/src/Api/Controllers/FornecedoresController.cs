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
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                    IMapper mapper,
                                    IFornecedorService fornecedorService,
                                    INotificador notificador, 
                                    IEnderecoRepository enderecoRepository) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
        {
            var fornecedores = await _fornecedorRepository.ObterTodos();

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

        [HttpGet("obter-endereco/{id:Guid}")]
        public async Task<ActionResult<EnderecoViewModel>> EnderecoPorId(Guid id)
        {
            var endereco = await _enderecoRepository.ObterPorId(id);

            if (endereco == null) return NotFound();

            var resultMap = _mapper.Map<EnderecoViewModel>(endereco);

            return resultMap;
        }

        [HttpPut("atualizar-endereco/{id:Guid}")]
        public async Task<ActionResult<EnderecoViewModel>> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var endereco = _mapper.Map<Endereco>(enderecoViewModel);

            await _fornecedorService.AtualizarEndereco(endereco);

            return CustomResponse(enderecoViewModel);
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            var fornecedorProdutosEndereco = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            return _mapper.Map<FornecedorViewModel>(fornecedorProdutosEndereco);
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            var fornecedorProdutosEndereco = await _fornecedorRepository.ObterFornecedorEndereco(id);

            return _mapper.Map<FornecedorViewModel>(fornecedorProdutosEndereco);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Adicionar(FornecedorViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fornecedor = _mapper.Map<Fornecedor>(model);

            await _fornecedorService.Adicionar(fornecedor);

            return CustomResponse(model);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id, FornecedorViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fornecedor = _mapper.Map<Fornecedor>(model);

            await _fornecedorService.Atualizar(fornecedor);

            return CustomResponse(model);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var fornecedor = ObterFornecedorEndereco(id);

            if (fornecedor == null) return NotFound();

            await _fornecedorService.Remover(id);

            return CustomResponse();
        }
    }
}
