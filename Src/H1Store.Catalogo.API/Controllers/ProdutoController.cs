using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Data.Providers.MongoDb.Interfaces;
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
	}
}
