using Aula_MVC_EntityFramework.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_EntityFramework.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProdutoController : Controller
	{
		[HttpGet]
		[Authorize(Roles = "promocao")]
		//public async Task<IActionResult> ListarProdutos()
		public IActionResult ListarProdutos()
		{
			var produtos = new[] { new { Id = 1, Nome = "Lápis" }, new { Id = 2, Nome = "Caneta" } };

			return Ok(produtos);
		}

		[HttpGet("{id}")]
		public IActionResult ObterProduto(int id)
		{
			var produto = new[] { new { Id = 1, Nome = "Lápis" }, new { Id = 2, Nome = "Caneta" } }
			.ToList().FirstOrDefault(x => x.Id == id);

			if (produto == null)
				return BadRequest();

			return Ok(produto);
		}

		[HttpPost]
		public IActionResult IncluirProduto([FromBody] ProdutoModel produto)
		{
			return Created("", produto);
		}

		//Para alterar todos os dados 
		[HttpPut]
		public IActionResult AlterarProdutoTodosOsCampos([FromBody] ProdutoModel produto)
		{
			new ProdutoModel[] { new ProdutoModel { Id = 1, Nome = "Lápis" }, new ProdutoModel { Id = 2, Nome = "Caneta" } }
		   .ToList().ForEach(x =>
		   {
			   x.Id = produto.Id;
			   x.Nome = produto.Nome;
			   x.Preco = produto.Preco;
		   });
			return Ok(produto);
		}

		//Para alterar Parcialmente
		[HttpPatch]
		public IActionResult AlterarProdutoPreco([FromBody] ProdutoModel produto)
		{
			new ProdutoModel[] { new ProdutoModel { Id = 1, Nome = "Lápis" }, new ProdutoModel { Id = 2, Nome = "Caneta" } }
			.ToList().ForEach(x =>
			{
				x.Preco = x.Preco;
			});
			return Ok(produto);
		}

		[HttpDelete("{id}")]
		public IActionResult ExcluirProduto(int id)
		{
			var produtos = new ProdutoModel[] { new ProdutoModel { Id = 1, Nome = "Lápis" }, new ProdutoModel { Id = 2, Nome = "Caneta" } };

			var produto = produtos.FirstOrDefault(x => x.Id == id);

			produtos.ToList().Remove(produto);

			return Ok("Produto excluído");
		}
	}
}
