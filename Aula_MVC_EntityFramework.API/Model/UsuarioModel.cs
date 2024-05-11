using Aula_MVC_EntityFramework.Application.DTOs;

namespace Aula_MVC_EntityFramework.API.Model
{
	public class UsuarioModel
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string[] Roles { get; set; }

		public static UsuarioDTO CarregarUsuario(int tipo)
		{
			switch (tipo)
			{
				case 1:
					return new UsuarioDTO
					{
						Email = "alexandre.araujo@fiap.com",
						Roles = new[] { "produto" }
					};

				default:
					return new UsuarioDTO();
			}
		}
	}
}
