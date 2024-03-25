using Aula_MVC_EntityFramework.Repositorio.Contexto;

namespace Aula_MVC_EntityFramework.Repositorio.Repositorios
{
	public class RepositorioBase<TEntity> where TEntity : class
	{
		protected ProdutoContext _produtoContext;

		public RepositorioBase(ProdutoContext produtoContext)
		{
			_produtoContext = produtoContext;
		}

		public IEnumerable<TEntity> ListarTodos()
		{
			return _produtoContext.Set<TEntity>().ToList();
		}

		public TEntity PesquisarPorId(int id)
		{
			return _produtoContext.Set<TEntity>().Find(id);
		}

		public void Incluir(TEntity entity)
		{
			_produtoContext.Set<TEntity>().Add(entity);
			_produtoContext.SaveChanges();
		}

		public void Alterar(TEntity entity)
		{
			_produtoContext.Set<TEntity>().Update(entity);
			_produtoContext.SaveChanges();
		}

		public void Excluir(int id)
		{
			var entity = PesquisarPorId(id);
			_produtoContext.Set<TEntity>().Remove(entity);
			_produtoContext.SaveChanges();
		}
	}
}
