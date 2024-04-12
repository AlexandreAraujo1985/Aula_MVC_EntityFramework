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

        public List<ProtudoDTO> ListarOsProdutosEmPromocao()
        {

            var produtosEmPromocao = from produto in _produtoContext.Produtos.ToList()
                                     join produtoEmPromocao in _produtoContext.ProdutosEmPromocao.ToList()
                                     on produto.Id equals produtoEmPromocao.ProdutoId
                                     select new ProtudoDTO
                                     {
                                         Id = produto.Id,
                                         DataCadastro = produto.DataCadastro,
                                         Preco = produto.Preco,
                                         PrecoPromocional = produtoEmPromocao.PrecoPromocional,
                                         DataInicio = produtoEmPromocao.DataInicio,
                                         DataFim = produtoEmPromocao.DataFim
                                     };

            return produtosEmPromocao.ToList();
        }

        public Produto FiltarPorNome(string nome) 
        {
            var produto = _produtoContext.Produtos.ToList().FirstOrDefault(x => x.Nome.Contains(nome));

            return produto;
        }

        public List<ProtudoDTO> ListarOsProdutosComESemPromocao()
        {

            var produtosEmPromocao = from produto in _produtoContext.Produtos.ToList()
                                     join produtoEmPromocao in _produtoContext.ProdutosEmPromocao.ToList()
                                     on produto.Id equals produtoEmPromocao.ProdutoId
                                     into produtosComESemPromocao
                                     select new ProtudoDTO
                                     {
                                         Id = produto.Id,
                                         DataCadastro = produto.DataCadastro,
                                         Preco = produto.Preco,
                                         PrecoPromocional = produtosComESemPromocao.FirstOrDefault()?.PrecoPromocional,
                                         DataInicio = produtosComESemPromocao.FirstOrDefault()?.DataInicio,
                                         DataFim = produtosComESemPromocao.FirstOrDefault()?.DataFim
                                     };

            return produtosEmPromocao.ToList();
        }
    }
}
