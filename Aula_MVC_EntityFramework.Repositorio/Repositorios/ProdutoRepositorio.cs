using Aula_MVC_EntityFramework.Repositorio.Contexto;
using Aula_MVC_EntityFramework.Repositorio.Entidades;

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
    }
}
