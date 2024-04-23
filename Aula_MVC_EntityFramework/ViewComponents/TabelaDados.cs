using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.MVC.Models;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;

namespace Aula_MVC_EntityFramework.MVC.ViewComponents
{
	public class TabelaDados : ViewComponent
	{
		private static ProdutoRepositorio produtoRepositorio;
		private static ForncedorRepositorio forncedorRepositorio;

		public TabelaDados()
		{
			produtoRepositorio = new ProdutoRepositorio(new Repositorio.Contexto.ProdutoContext());
			forncedorRepositorio = new ForncedorRepositorio(new Repositorio.Contexto.ProdutoContext());
		}

		private Dictionary<string, Func<object>> tipoDeDados = new Dictionary<string, Func<object>>()
		{
			  { "Produto",  CriarDadosProduto},
		};

		public KeyValuePair<string, Func<object>> this[string tipo] =>
			tipoDeDados.FirstOrDefault(x => x.Key == tipo);

		public IViewComponentResult Invoke(string tipoDados)
		{
			var tipoDeRelatorio = this[tipoDados];

			ViewData["NameController"] = tipoDeRelatorio.Key;

			var numeroPaginas = int.Parse(ViewData["NumeroPaginas"].ToString());

			var dadosRelatorio = tipoDeRelatorio.Value.Invoke() as List<TabelaDadosBaseModel> ?? new List<TabelaDadosBaseModel>();

			var nome = ViewData["NomeDoProduto"] as string;

			if (!string.IsNullOrEmpty(nome))
			{
				dadosRelatorio = dadosRelatorio
					.Where(x => x.Itens["Nome"].ToLower().Contains(nome))
					.ToList();
			}

			var limitePaginas = 6;
			return View(Paginador<TabelaDadosBaseModel>.CriarPaginacao(dadosRelatorio.AsQueryable(), numeroPaginas, limitePaginas));
		}

		private static List<TabelaDadosBaseModel> CriarDadosProduto()
		{
			var listaDeProdutosRepositorio = produtoRepositorio.ListarTodos();

			var listaDeProdutos = listaDeProdutosRepositorio.Select(produto =>
			{
				return new TabelaDadosBaseModel
				{
					Id = produto.Id,
					Itens = new Dictionary<string, string>
					{
						{ nameof(produto.Nome), produto.Nome.ToString() },
						{ nameof(produto.Preco), produto.Preco.FormatarMoeda() },
						{ nameof(produto.DataCadastro), produto.DataCadastro.FormatarData() }
					}
				};
			}).ToList();

			return listaDeProdutos;
		}
	}
}
