using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.MVC.Models;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;
using Aula_MVC_EntityFramework.Repositorio.Entidades;

namespace Aula_MVC_EntityFramework.MVC.Contrllers
{
	public class ProdutoController : Controller
	{
		private ProdutoRepositorio produtoRepositorio;
		private ForncedorRepositorio forncedorRepositorio;

		public ProdutoController()
		{
			produtoRepositorio = new ProdutoRepositorio(new Repositorio.Contexto.ProdutoContext());
			forncedorRepositorio = new ForncedorRepositorio(new Repositorio.Contexto.ProdutoContext());
		}

		[HttpGet]
		public IActionResult ProdutosEmPromocao()
		{
			var produtosEmPromocao = produtoRepositorio
				.ListarOsProdutosEmPromocao()
				.Select(x =>
				{
					return new ProdutoModel { Id = x.Id, Nome = x.Nome, DataCadastro = x.DataCadastro, Preco = x.Preco };
				}).ToList();

			return View(produtosEmPromocao);
		}

		[HttpGet]
		public IActionResult ListarProdutosFornecedor()
		{
			var produtosFornecedor = produtoRepositorio.ListarProdutosFornecedor()
				.Select(x =>
				{
					return new ProdutoFornecedorModel
					{
						ProdutoId = x.ProdutoId,
						DataCadastroFornecedor = x.DataCadastroFornecedor,
						DataCadastroProduto = x.DataCadastroProduto,
						NomeFornecedor = x.NomeFornecedor,
						NomeProduto = x.NomeProduto
					};
				}).ToList();

			return View(produtosFornecedor);
		}

		[HttpGet]
		public IActionResult Index(string ordenarDados)
		{
			ViewData["NomeOrdenado"] = string.IsNullOrEmpty(ordenarDados) ? "nome_desc" : "";
			ViewData["PrecoOrdenado"] = ordenarDados == "preco" ? "preco_desc" : "preco";

			var listaDeProdutos = produtoRepositorio
				.ListarTodos()
				.Select(x =>
				{
					return new ProdutoModel
					{
						Id = x.Id,
						DataCadastro = x.DataCadastro,
						Nome = x.Nome,
						Preco = x.Preco
					};
				}).ToList();

			switch (ordenarDados)
			{
				case "nome_desc":
					listaDeProdutos = listaDeProdutos.OrderByDescending(x => x.Nome).ToList();
					break;

				case "preco":
					listaDeProdutos = listaDeProdutos.OrderBy(x => x.Preco).ToList();
					break;

				case "preco_desc":
					listaDeProdutos = listaDeProdutos.OrderByDescending(x => x.Preco).ToList();
					break;

				default:
					listaDeProdutos = listaDeProdutos.OrderBy(x => x.Nome).ToList();
					break;
			}

			return View(listaDeProdutos);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var listaForcedores = forncedorRepositorio.ListarTodos().ToList();
			var produto = new ProdutoModel();

			listaForcedores.ForEach(x =>
			{
				produto.Fornecedores.Add(new FornecedorModel
				{
					Ativo = x.Ativo,
					DataCadastro = x.DataCadastro,
					Id = x.Id,
					Nome = x.Nome
				});
			});

			return View(produto);
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			var produto = produtoRepositorio.PesquisarPorId(id);

			var produtoModel = new ProdutoModel
			{
				Id = produto.Id,
				DataCadastro = produto.DataCadastro,
				Nome = produto.Nome,
				Preco = produto.Preco
			};

			return View(produtoModel);
		}

		[HttpPost]
		public IActionResult Create(ProdutoModel produto)
		{
			var produtoEntity = produtoRepositorio.PesquisarPorId(produto.Id);

			//if (produto.Nome.ToUpper() != produtoEntity.Nome.ToUpper())
			//{
			if (ModelState.IsValid)
			{
				produtoRepositorio.Incluir(new Produto
				{
					Id = produto.Id,
					DataCadastro = DateTime.Now,
					Nome = produto.Nome,
					Preco = produto.Preco,
					FornecedorId = produto.FornecedorId,
				});

				return RedirectToAction("Index");
			}
			//}

			ViewData["Mensagem"] = $"O produto:{produto.Nome}. Já existe!!!";

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
				Preco = produto.Preco,
				FornecedorId = produto.FornecedorId
			};

			return View(produtoViewModel);
		}


		[HttpPost]
		public IActionResult Edit(ProdutoModel produto)
		{
			if (ModelState.IsValid)
			{
				produtoRepositorio.Alterar(new Produto
				{
					Id = produto.Id,
					Nome = produto.Nome,
					Preco = produto.Preco,
					FornecedorId = produto.FornecedorId
				});

				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var produto = produtoRepositorio.PesquisarPorId(id);

			var produtoModel = new ProdutoModel
			{
				Id = produto.Id,
				Nome = produto.Nome,
				Preco = produto.Preco,
				DataCadastro = produto.DataCadastro
			};

			return View(produtoModel);
		}

		[HttpPost]
		public IActionResult Delete(ProdutoModel produto)
		{
			produtoRepositorio.Excluir(produto.Id);

			return RedirectToAction("Index");
		}
	}
}
