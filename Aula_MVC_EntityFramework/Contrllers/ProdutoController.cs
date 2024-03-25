using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.Models;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;

namespace Aula_MVC_EntityFramework.Contrllers
{
	public class ProdutoController : Controller
	{
		//private List<ProdutoModel> ListarProdutos()
		//{
		//	return new List<ProdutoModel>
		//	{
		//		new ProdutoModel { Id = 1, Nome = "Caneta", Preco = 2 },
		//		new ProdutoModel { Id = 2, Nome = "Lápis", Preco = 1 },
		//		new ProdutoModel { Id = 3, Nome = "Caderno", Preco = 10 }
		//	};
		//}

		private ProdutoRepositorio produtoRepositorio;

		public ProdutoController()
		{
			produtoRepositorio = new ProdutoRepositorio(new Repositorio.Contexto.ProdutoContext());
		}

		[HttpGet]
		public IActionResult Index()
		{
			var listarProdutos = produtoRepositorio.ListarTodos();

			return View(listarProdutos);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var produto = produtoRepositorio.PesquisarPorId(id);

			return View(produto);
		}

		[HttpPost]
		public IActionResult Create(ProdutoModel produto)
		{
			if (ModelState.IsValid)
			{
				produtoRepositorio.Incluir(new Repositorio.Entidades.Produto
				{
					Id = produto.Id,
					DataCadastro = DateTime.Now,
					Nome = produto.Nome,
					Preco = produto.Preco
				});

				var listarProdutos = produtoRepositorio.ListarTodos();

				return View("Index", listarProdutos.ToList());
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var produto = produtoRepositorio.PesquisarPorId(id);

			produtoRepositorio.Alterar(produto);

			var produtoViewModel = new ProdutoModel
			{
				Id = produto.Id,
				Nome = produto.Nome,
				Preco = produto.Preco
			};

			return View(produtoViewModel);
		}


		[HttpPost]
		public IActionResult Edit(ProdutoModel produto)
		{
			//if (ModelState.IsValid)
			//{
			//	var produtosAtualizados = ListarProdutos()
			//			.Select(x =>
			//			{
			//				if (x.Id == produto.Id)
			//				{
			//					x.Nome = produto.Nome;
			//					x.Preco = produto.Preco;
			//				}
			//				return x;
			//			}).ToList();

			//	return View("Index", produtosAtualizados);
			//}

			return View();
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			//var produto = ListarProdutos().Find(x => x.Id == id);

			//return View(produto);
			return View();
		}

		[HttpPost]
		public IActionResult Delete(ProdutoModel produto)
		{
			//var produtos = ListarProdutos();
			//var produtoExcluido = produtos.First(x => x.Id == produto.Id);

			//produtos.Remove(produtoExcluido);

			//return View("Index", produtos);
			return View();
		}
	}
}
