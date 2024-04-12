using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.Models;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;

namespace Aula_MVC_EntityFramework.Contrllers
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
        public IActionResult Index()
        {
            var listarProdutos = produtoRepositorio
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

            return View();
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

            return View();
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
                    Preco = produto.Preco,
                    FornecedorId = 1
                });

                var listarProdutos = produtoRepositorio
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

                return View("Index", listarProdutos);
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
            if (ModelState.IsValid)
            {
                var produtosAtualizados = produtoRepositorio
                    .ListarTodos()
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

            return View("Index");
        }
    }
}
