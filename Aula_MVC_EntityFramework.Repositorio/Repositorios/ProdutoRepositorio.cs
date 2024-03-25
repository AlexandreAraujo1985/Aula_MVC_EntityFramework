﻿using Aula_MVC_EntityFramework.Repositorio.Contexto;
using Aula_MVC_EntityFramework.Repositorio.Entidades;

namespace Aula_MVC_EntityFramework.Repositorio.Repositorios
{
	public class ProdutoRepositorio : RepositorioBase<Produto>
	{
		public ProdutoRepositorio(ProdutoContext produtoContext) : base(produtoContext)
		{
		}
	}
}
