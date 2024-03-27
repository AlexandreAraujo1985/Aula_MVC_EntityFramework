using Microsoft.EntityFrameworkCore;
using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Aula_MVC_EntityFramework.Repositorio.Configuracoes;

namespace Aula_MVC_EntityFramework.Repositorio.Contexto
{
	public class ProdutoContext : DbContext
	{
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Fornecedor> Fornecedores { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
			modelBuilder.ApplyConfiguration(new FornecedorConfiguration());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source =.\sqlexpress; Initial Catalog=fiap_entity_framawork; Integrated Security = True; Encrypt=False");
			//optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;database=library;user=root;password=");
		}
	}
}
