using Aula_MVC_EntityFramework.API.Model;
using Aula_MVC_EntityFramework.Application.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace Aula_MVC_EntityFramework.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SignController : ControllerBase
	{
		private readonly TokenService _tokenService;

		public SignController(TokenService tokenService)
		{
			_tokenService = tokenService;
		}

		[HttpPost]
		[AllowAnonymous]
		public IActionResult Autenticar([FromBody] UsuarioModel usuarioModel)
		{
			var token = _tokenService.GerarToken(UsuarioModel.CarregarUsuario(1));

			if (IsNullOrEmpty(token))
				return NotFound();

			return Ok(token);
		}
	}
}
