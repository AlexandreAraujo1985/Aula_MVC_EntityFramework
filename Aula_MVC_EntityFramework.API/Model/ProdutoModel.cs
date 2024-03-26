using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aula_MVC_EntityFramework.API.Model
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}
