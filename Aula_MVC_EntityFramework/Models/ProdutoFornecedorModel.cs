namespace Aula_MVC_EntityFramework.MVC.Models
{
    public class ProdutoFornecedorModel
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataCadastroProduto { get; set; }
        public string NomeFornecedor { get; set; }
        public DateTime DataCadastroFornecedor { get; set; }
    }
}
