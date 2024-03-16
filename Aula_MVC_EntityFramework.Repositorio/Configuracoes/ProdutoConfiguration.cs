using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula_MVC_EntityFramework.Repositorio.Configuracoes
{
	public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
	{
		void IEntityTypeConfiguration<Produto>.Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.ToTable("tb_produto");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)");

			builder.Property(x => x.Preco).HasColumnName("preco").HasColumnType("number");

			builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro").HasColumnType("datetime");
		}
	}
}
