using H1Store.Catalogo.Infra.EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace H1Store.Catalogo.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TesteEmailController : ControllerBase
	{
		private readonly EmailConfig _emailConfig;

		public TesteEmailController(IOptions<EmailConfig> options)
		{
			_emailConfig = options.Value;
		}

		[HttpPost]
		[Route("EnviarEmail")]
		public async Task<IActionResult> Post()
		{
			string assunto = "Teste E-mail";
			string corpoEmailModelo = "Olá {nomeCliente} teste E-mail. ";
			string nome = "h1";
			string emailDestino = "1bertomelo@gmail.com";

			string corpoEmail = corpoEmailModelo.Replace("{nomeCliente}", nome);

			if (!string.IsNullOrEmpty(emailDestino))
				Email.Enviar(assunto, corpoEmail, emailDestino, _emailConfig);

			return Ok("Emails Enviado Com Sucesso!");

		}
	}
}
