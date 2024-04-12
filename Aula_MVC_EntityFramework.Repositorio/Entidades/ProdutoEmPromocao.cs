namespace Aula_MVC_EntityFramework.Repositorio.Entidades
{
    public class ProdutoEmPromocao
    {
        public int ProdutoEmPromocaoId { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal PrecoPromocional { get; set; }
    }
}
