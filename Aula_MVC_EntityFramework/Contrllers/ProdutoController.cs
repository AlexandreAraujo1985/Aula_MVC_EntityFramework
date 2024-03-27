using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.Models;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;

namespace Aula_MVC_EntityFramework.Contrllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepositorio produtoRepositorio;

        public ProdutoController()
        {
            produtoRepositorio = new ProdutoRepositorio(new Repositorio.Contexto.ProdutoContext());
        }

        [HttpGet]
        public IActionResult ProdutosEmPromocao()
        {
            //var produtosEmPromocao = produtoRepositorio.ProdutosEmPromocao();

            var produtosEmPromocao = new[]
            {
                new ProdutoModel { Id = 1, Nome = "Caneta", DataCadastro = DateTime.Now, Preco = 1.99m },
                new ProdutoModel { Id = 2, Nome = "Mochila", DataCadastro = DateTime.Now, Preco = 99.00m }
            }
            .Where(x => x.Preco < 5.00m)
            .ToList();

            return View(produtosEmPromocao);
        }

        [HttpGet]
        public IActionResult ListarProdutosFornecedor()
        {
            var produtos = new[]
            {
                new ProdutoModel { Id = 1, Nome = "Caneta", DataCadastro = DateTime.Now, Preco = 1.99m },
                new ProdutoModel { Id = 2, Nome = "Mochila", DataCadastro = DateTime.Now, Preco = 99.00m }
            };

            var fornecedores = new[]
            {
                new FornecedorModel { Id = 1, Nome = "Bic", Ativo = true, DataCadastro = DateTime.Now },
                new FornecedorModel { Id = 2, Nome = "Fiap", Ativo = true, DataCadastro = DateTime.Now }
            };

            var produtosFornecedor = from produto in produtos
                                     join fornecedor in fornecedores
                                     on produto.Id equals fornecedor.Id
                                     select new ProdutoFornecedorModel
                                     {
                                         ProdutoId = produto.Id,
                                         NomeProduto = produto.Nome,
                                         DataCadastroProduto = produto.DataCadastro,
                                         NomeFornecedor = fornecedor.Nome,
                                         DataCadastroFornecedor = fornecedor.DataCadastro
                                     };
            return View(produtosFornecedor.ToList());
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var listarProdutos = produtoRepositorio.ListarTodos();

            return View(new List<ProdutoModel> { new ProdutoModel { Id = 1, Nome = "Caneta", Preco = 1.99m } });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var produto = new ProdutoModel
            {
                Fornecedores = new List<FornecedorModel>
                {
                    new FornecedorModel { Id = 1, Nome = "Bic", Ativo = true, DataCadastro = DateTime.Now },
                    new FornecedorModel { Id = 2, Nome = "Fiap", Ativo = true, DataCadastro = DateTime.Now }
                }
            };

            return View(produto);
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
