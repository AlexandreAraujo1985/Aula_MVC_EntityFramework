namespace Aula_MVC_EntityFramework.Repositorio.Repositorios.DTOs
{
    public class ProdutosFornecedorDTO
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataCadastroProduto { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime DataCadastroFornecedor { get; set; }
    }
}
