using Aula_MVC_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_EntityFramework.Contrllers
{
	public class ProdutoController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			var produtos = new[]
			{
				new Produto { Id = 1, Nome = "Caneta", Preco = 2 },
				new Produto { Id = 2, Nome = "Lápis", Preco = 1 },
				new Produto { Id = 3, Nome = "Caderno", Preco = 10 }
			}.ToList();

			return View(produtos);
		}
	}
}
