using Aula_MVC_EntityFramework.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_EntityFramework.MVC.Contrllers
{
	public class FornecedorController : Controller
	{
		private readonly FornecedorRepositorio fornecedorRepositorio;

		public FornecedorController()
		{
			fornecedorRepositorio = new FornecedorRepositorio(new Repositorio.Contexto.ProdutoContext());
		}

		public IActionResult Index(string ordenarDados, string pesquisarProduto, int numeroPaginas = 1)
		{
			ViewData["NomeOrdenado"] = string.IsNullOrEmpty(ordenarDados) ? "nome_desc" : "";
			ViewData["PrecoOrdenado"] = ordenarDados == "preco" ? "preco_desc" : "preco";
			ViewData["NomeDoProduto"] = pesquisarProduto;

			ViewData["NumeroPaginas"] = numeroPaginas;

			ViewBag.Dados = new { OrdenarDados = ordenarDados, PesquisarProduto = pesquisarProduto };

			return View();
		}
	}
}
