using AutoMapper;
using H1Store.Catalogo.Application.Interfaces;
using H1Store.Catalogo.Application.ViewModels;
using H1Store.Catalogo.Infra.Autenticacao;
using Microsoft.AspNetCore.Mvc;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsuarioController : ControllerBase
	{
		private readonly ITokenService _tokenService;
		private readonly IUsuarioService _usuarioService;
		private readonly IMapper _mapper;

		public UsuarioController(IUsuarioService usuarioService, IMapper mapper,
			 ITokenService tokenService)
		{
			_usuarioService = usuarioService;
			_mapper = mapper;
			_tokenService = tokenService;
		}

		[HttpPost]
		public async Task<IActionResult> Autenticar(AutenticarUsuarioViewModel autenticarUsuarioViewModel)
		{
			var token = await _usuarioService.Autenticar(autenticarUsuarioViewModel);

			return Ok(token);
		}
	}
}
