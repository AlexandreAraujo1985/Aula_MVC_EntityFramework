using System.ComponentModel.DataAnnotations;

namespace Aula_MVC_EntityFramework.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é requerido")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é requerido")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        public List<FornecedorModel> Fornecedores { get; set; } = new List<FornecedorModel>();
    }
}
