using Aula_MVC_EntityFramework.Repositorio.Contexto;
using Aula_MVC_EntityFramework.Repositorio.Entidades;

namespace Aula_MVC_EntityFramework.Repositorio.Repositorios
{
	public class ForncedorRepositorio : RepositorioBase<Fornecedor>
	{
		public ForncedorRepositorio(ProdutoContext produtoContext) : base(produtoContext)
		{
		}
	}
}
