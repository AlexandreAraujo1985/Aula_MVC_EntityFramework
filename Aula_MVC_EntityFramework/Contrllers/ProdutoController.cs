using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.Models;

namespace Aula_MVC_EntityFramework.Contrllers
{
	public class ProdutoController : Controller
	{
		private List<Produto> ListarProdutos()
		{
			return new List<Produto>
			{
				new Produto { Id = 1, Nome = "Caneta", Preco = 2 },
				new Produto { Id = 2, Nome = "Lápis", Preco = 1 },
				new Produto { Id = 3, Nome = "Caderno", Preco = 10 }
			};
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View(ListarProdutos());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var produto = ListarProdutos().Find(x => x.Id == id);

			return View(produto);
		}

		[HttpPost]
		public IActionResult Create(Produto produto)
		{
			if (ModelState.IsValid)
			{
				var produtos = ListarProdutos();

				produto.Id = 4;
				produtos.Add(produto);

				return View("Index", produtos);
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var produto = ListarProdutos().Find(x => x.Id == id);

			return View(produto);
		}


		[HttpPost]
		public IActionResult Edit(Produto produto)
		{
			if (ModelState.IsValid)
			{
				var produtosAtualizados = ListarProdutos()
						.Select(x =>
						{
							if (x.Id == produto.Id)
							{
								x.Nome = produto.Nome;
								x.Preco = produto.Preco;
							}
							return x;
						}).ToList();

				return View("Index", produtosAtualizados);
			}

			return View();
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var produto = ListarProdutos().Find(x => x.Id == id);

			return View(produto);
		}

		[HttpPost]
		public IActionResult Delete(Produto produto)
		{
			var produtos = ListarProdutos();
			var produtoExcluido = produtos.First(x => x.Id == produto.Id);

			produtos.Remove(produtoExcluido);

			return View("Index", produtos);
		}
	}
}
