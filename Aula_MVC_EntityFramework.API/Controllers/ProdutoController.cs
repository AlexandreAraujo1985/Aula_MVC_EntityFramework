using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_EntityFramework.API.Controllers
{
	[Route("api/[controller]")]
	public class ProdutoController : Controller
	{
		//api/produto/1
		[HttpGet("{id}")]
		public IActionResult BuscarProduto(int id)
		{
			return Ok(new { id = 1, Nome = "Caneta", Preco = 1.99m });
		}
	}
}
