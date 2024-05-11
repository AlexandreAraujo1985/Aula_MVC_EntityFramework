using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Aula_MVC_EntityFramework.Application.DTOs;

namespace Aula_MVC_EntityFramework.Application.Authentication
{
	public class TokenService
	{
		public string GerarToken(UsuarioDTO usuarioDTO)
		{
			var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.UTF8.GetBytes(Configuracao.ChavePrivada);

			var securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Role, usuarioDTO.Email),
					new Claim(ClaimTypes.Role, string.Join(",", usuarioDTO.Roles) )
				}),

				Expires = DateTime.UtcNow.AddHours(2),

				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
									SecurityAlgorithms.HmacSha256Signature)
			};

			var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
			var jwt = jwtSecurityTokenHandler.WriteToken(token);

			return jwt;
		}
	}
}
