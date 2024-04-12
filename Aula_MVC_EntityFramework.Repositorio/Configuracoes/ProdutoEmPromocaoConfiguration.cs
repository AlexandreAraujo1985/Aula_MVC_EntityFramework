using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula_MVC_EntityFramework.Repositorio.Configuracoes
{
    public class ProdutoEmPromocaoConfiguration : IEntityTypeConfiguration<ProdutoEmPromocao>
    {
        public void Configure(EntityTypeBuilder<ProdutoEmPromocao> builder)
        {
            builder.ToTable("tb_produto_em_promocao");

            builder.HasKey(x => x.ProdutoEmPromocaoId);

            builder.Property(x => x.ProdutoEmPromocaoId).HasColumnName("id");

            builder.Property(x => x.ProdutoId).HasColumnName("produto_id");

            builder.Property(x => x.DataInicio).HasColumnName("data_inicio").HasColumnType("datetime");

            builder.Property(x => x.DataFim).HasColumnName("data_fim").HasColumnType("datetime"); ;

            builder.Property(x => x.PrecoPromocional).HasColumnName("preco_promocional").HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Produto).WithMany(x => x.ProdutosEmPromocao).HasForeignKey(x => x.ProdutoId);
        }
    }
}
