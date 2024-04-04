using Aula_MVC_EntityFramework.Repositorio.Contexto;
using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Aula_MVC_EntityFramework.Repositorio.Repositorios.DTOs;

namespace Aula_MVC_EntityFramework.Repositorio.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>
    {
        public ProdutoRepositorio(ProdutoContext produtoContext) : base(produtoContext)
        {
        }

        public List<Produto> ProdutosEmPromocao()
        {
            return _produtoContext.Produtos.Where(x => x.Preco < 5.00m).ToList();
        }

        public List<ProdutosFornecedorDTO> ListarProdutosFornecedor()
        {
            var listarProdutosFornecedor = from produto in _produtoContext.Produtos.ToList()
                                           join fornecedor in _produtoContext.Fornecedores.ToList()
                                           on produto.FornecedorId equals fornecedor.Id
                                           select new ProdutosFornecedorDTO
                                           {
                                               ProdutoId = produto.Id,
                                               DataCadastroFornecedor = fornecedor.DataCadastro,
                                               DataCadastroProduto = produto.DataCadastro,
                                               NomeFornecedor = fornecedor.Nome,
                                               NomeProduto = produto.Nome
                                           };

            return listarProdutosFornecedor.ToList();
        }
    }
}
