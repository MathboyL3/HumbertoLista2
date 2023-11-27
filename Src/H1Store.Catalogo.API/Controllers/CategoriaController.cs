using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoriaController : ControllerBase
	{
		private readonly ICategoriaService _categoriaService;
		public CategoriaController(ICategoriaService categoriaService)
		{
			_categoriaService = categoriaService;
		}

		[HttpPost]
		[Route("Adicionar")]
		public async Task<IActionResult> Post(NovaCategoriaViewModel categoriaViewModel)
		{
			await _categoriaService.Adicionar(categoriaViewModel);

			return Ok();
		}

		[HttpGet]
		[Route("ObterTodas")]
		public IActionResult Get()
		{
			return Ok(_categoriaService.ObterTodas());
		}

		[HttpGet]
		[Route("ObterPorId/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
		{
            return Ok(await _categoriaService.ObterPorId(id));
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody]NovaCategoriaViewModel categoriaViewModel)
		{
			_categoriaService.Atualizar(id, categoriaViewModel);
            return Ok("Categoria atualizada com sucesso!");
        }

        [HttpPut]
        [Route("Desativar/{id}")]
        public async Task<IActionResult> Desativar(Guid id)
		{
			await _categoriaService.Desativar(id);
            return Ok("Categoria desativada com sucesso!");
        }

        [HttpPut]
        [Route("Ativar/{id}")]
        public async Task<IActionResult> Ativar(Guid id)
		{
			await _categoriaService.Ativar(id);
            return Ok("Categoria ativada com sucesso!");
        }
    }
}

