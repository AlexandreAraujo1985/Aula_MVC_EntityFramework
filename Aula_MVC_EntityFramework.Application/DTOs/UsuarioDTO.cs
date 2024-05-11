namespace Aula_MVC_EntityFramework.Application.DTOs
{
	public record UsuarioDTO
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string[] Roles { get; set; }
	}
}
