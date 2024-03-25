namespace Aula_MVC_EntityFramework.Repositorio.Entidades
{
	public class Fornecedor
	{
		public int Id { get; set; }
		public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }
    }
}
