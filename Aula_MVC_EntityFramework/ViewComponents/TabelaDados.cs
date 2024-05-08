using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.MVC.Models;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;
using Aula_MVC_EntityFramework.Repositorio.Entidades;
using System.Linq;

namespace Aula_MVC_EntityFramework.MVC.ViewComponents
{
    public class TabelaDados : ViewComponent
    {
        private static ProdutoRepositorio produtoRepositorio;
        private static FornecedorRepositorio forncedorRepositorio;

        public TabelaDados()
        {
            produtoRepositorio = new ProdutoRepositorio(new Repositorio.Contexto.ProdutoContext());
            forncedorRepositorio = new FornecedorRepositorio(new Repositorio.Contexto.ProdutoContext());
        }

        private Dictionary<string, Func<object>> tipoDeDados = new Dictionary<string, Func<object>>()
        {
              { "Produto",  CriarDadosProduto },
              { "Fornecedor", CriarDadosFornecedor },
              { "ProdutosEmPromocao", CriarDadosProdutosEmPromocao }
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
                    UtilizaLink = true,
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

        private static List<TabelaDadosBaseModel> CriarDadosFornecedor()
        {
            var listaDeFornecedoresRepositorio = forncedorRepositorio.ListarTodos();

            var listaDeFornecedores = listaDeFornecedoresRepositorio.Select(fornecedor =>
            {
                return new TabelaDadosBaseModel
                {
                    Id = fornecedor.Id,
                    UtilizaLink = true,
                    Itens = new Dictionary<string, string>
                    {
                        { nameof(fornecedor.Nome), fornecedor.Nome.ToString() },
                        { nameof(fornecedor.DataCadastro), fornecedor.DataCadastro.FormatarData() }
                    }
                };
            }).ToList();

            return listaDeFornecedores;
        }

        private static List<TabelaDadosBaseModel> CriarDadosProdutosEmPromocao()
        {
            var produtosEmPromocao = produtoRepositorio
                .ListarOsProdutosEmPromocao()
                .Select(produto =>
                {
                    return new TabelaDadosBaseModel
                    {
                        Id = produto.Id,
                        UtilizaLink = false,
                        Itens = new Dictionary<string, string>
                        {
                            { nameof(produto.Id), produto.Id.ToString()},
                            { nameof(produto.DataCadastro) , produto.DataCadastro.FormatarData() },
                            { nameof(produto.Preco) , produto.Preco.FormatarMoeda()},
                            { nameof(produto.PrecoPromocional) , produto.PrecoPromocional.Value.FormatarMoeda()},
                            { nameof(produto.DataInicio) , produto.DataInicio.Value.FormatarData()},
                            { nameof(produto.DataFim) ,produto.DataFim.Value.FormatarData()}
                        }
                    };
                }).ToList();

            return produtosEmPromocao;
        }
    }
}
