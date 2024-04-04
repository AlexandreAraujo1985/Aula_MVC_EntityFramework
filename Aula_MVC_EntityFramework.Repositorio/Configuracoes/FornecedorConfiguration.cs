using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula_MVC_EntityFramework.Repositorio.Configuracoes
{
	public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
	{
		public void Configure(EntityTypeBuilder<Fornecedor> builder)
		{
			builder.ToTable("tb_fornecedor");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id).HasColumnName("id");

			builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)");

			builder.Property(x => x.DataCadastro).HasColumnName("data_cadastro").HasColumnType("varchar(50)");

			builder.Property(x => x.Ativo).HasColumnName("ativo");

			builder.HasMany(x => x.Produtos).WithOne(x => x.Fornecedor).HasForeignKey(x => x.FornecedorId).HasPrincipalKey(x => x.Id);
		}
	}
}
