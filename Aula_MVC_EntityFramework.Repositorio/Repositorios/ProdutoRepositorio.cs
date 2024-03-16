using Aula_MVC_EntityFramework.Repositorio.Contexto;
using Aula_MVC_EntityFramework.Repositorio.Entidades;

namespace Aula_MVC_EntityFramework.Repositorio.Repositorios
{
	public class ProdutoRepositorio : ProdutoContext
	{
		public IEnumerable<Produto> ListarTodos()
		{
			return Produtos.ToList();
		}

		public Produto PesquisarPorId(int id)
		{
			return Produtos.Find(id);
		}

		public void Incluir(Produto produto)
		{
			Produtos.Add(produto);
		}

		public void Alterar(Produto produto)
		{
			Produtos.Update(produto);
		}

		public void Excluir(int id)
		{
			var produto = PesquisarPorId(id);
			Produtos.Remove(produto);
		}
	}
}
