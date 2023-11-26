using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.Services;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FornecedorController : ControllerBase
	{
		private readonly IFornecedorService _fornecedorService;

		public FornecedorController(IFornecedorService fornecedorService)
		{
			_fornecedorService = fornecedorService;
		}

		[HttpPost]
		[Route("Adicionar")]
		public async Task<IActionResult> Post(NovoFornecedorViewModel novoFornecedorViewModel)
		{
		
			await _fornecedorService.Adicionar(novoFornecedorViewModel);

			return Ok("Fornecedor cadastrado com sucesso");
		}

		[HttpGet]
		[Route("ObterTodos")]
		public async Task<IActionResult> Get()
		{
			return Ok(await _fornecedorService.ObterTodos());
		}

		[HttpGet]
		[Route("ObterPorCnpj/{cnpj}")]
		public async Task<IActionResult> Get(string cnpj)
		{
			var buscaCnpj = await _fornecedorService.ObterPorCnpj(cnpj);
			if(buscaCnpj == null) return NotFound("Cnpj Não encontrado");
			return Ok(buscaCnpj);
		}

        [HttpPut]
        [Route("Atualizar/{cnpj}")]

        public async Task<IActionResult> Atualizar([FromBody] NovoFornecedorViewModel produto)
        {
            _fornecedorService.Atualizar(produto);

            return Ok("Produto modificado com sucesso!");
        }

        [HttpPut]
        [Route("Desativar/{id}")]
        public async Task<IActionResult> Desativar(string cnpj)
        {
            await _fornecedorService.Desativar(cnpj);

            return Ok("Produto desativado com sucesso");
        }

        [HttpPut]
        [Route("Ativar/{id}")]
        public async Task<IActionResult> Ativar(string cnpj)
        {
            await _fornecedorService.Ativar(cnpj);

            return Ok("Produto ativado com sucesso");
        }

        [HttpGet]
        [Route("ObterPorNome/{nome}")]
        public async Task<IActionResult> ObterPorNome(string nome)
        {
            return Ok(await _fornecedorService.ObterPorNome(nome));
        }

    }
}
