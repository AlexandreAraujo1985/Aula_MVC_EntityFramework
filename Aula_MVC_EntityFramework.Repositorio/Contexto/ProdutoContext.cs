using Microsoft.EntityFrameworkCore;
using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Aula_MVC_EntityFramework.Repositorio.Configuracoes;

namespace Aula_MVC_EntityFramework.Repositorio.Contexto
{
	public class ProdutoContext : DbContext
	{
		public DbSet<Produto> Produtos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer("");
		}
	}
}
