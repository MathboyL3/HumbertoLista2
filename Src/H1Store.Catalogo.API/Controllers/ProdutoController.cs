using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
using H1Store.Catalogo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IProdutoService _produtoService;
		public ProdutoController(IProdutoService produtoService)
		{
			_produtoService = produtoService;
		}

		[HttpPost]
		[Route("Adicionar")]
		public async Task<IActionResult> Post(NovoProdutoViewModel novoProdutoViewModel)
		{
			await _produtoService.Adicionar(novoProdutoViewModel);

			return Ok();
		}

		[HttpPut]
		[Route("Desativar/{id}")]
		public async Task<IActionResult> Put(Guid id)
		{
			await _produtoService.Desativar(id);

			return Ok("Produto desativado com sucesso");
		}

		[HttpGet]
		[Route("ObterTodos")]
		public IActionResult Get()
		{
			return Ok(_produtoService.ObterTodos());
		}

        [HttpGet]
        [Route("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
		{
            return Ok(await _produtoService.ObterPorId(id));
        }

        [HttpGet]
        [Route("ObterPorCategoria/{categoria_id}")]
        public async Task<IActionResult> ObterPorCategoria(Guid categoria_id)
		{
            return Ok(await _produtoService.ObterPorCategoria(categoria_id));
        }

        [HttpGet]
        [Route("ObterPorNome/{nome}")]
        public async Task<IActionResult> ObterPorNome(string nome)
		{
            return Ok(await _produtoService.ObterPorNome(nome));
        }

        [HttpPatch]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] NovoProdutoViewModel produto)
		{
			_produtoService.Atualizar(id, produto);
            return Ok("Produto atualizado com sucesso!");
        }

        [HttpPut]
        [Route("Ativar/{id}")]
        public async Task<IActionResult> Ativar(Guid id)
		{
			await _produtoService.Ativar(id);
            return Ok("Produto ativado com sucesso!");
        }

        [HttpPut]
        [Route("AlterarPreco/{id}/{newPreco}")]
        public async Task<IActionResult> AlterarPreco(Guid id, decimal newPreco)
		{
            await _produtoService.AlterarPreco(id, newPreco);
            return Ok("Produto alterado preço com sucesso!");
        }

        [HttpPut]
        [Route("AtualizarEstoque/{id}/{quantidade}")]
        public async Task<IActionResult> AtualizarEstoque(Guid id, int quantidade)
		{
            await _produtoService.AtualizarEstoque(id, quantidade);
            return Ok("Produto atualizado estoque com sucesso!");
        }
    }
}
