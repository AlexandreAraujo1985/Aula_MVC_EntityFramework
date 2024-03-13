using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace Aula_MVC_EntityFramework.Models
{
	public class Produto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Nome é requerido")]
		[Display(Name = "Nome")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Preço é requerido")]
		[Display(Name = "Preço")]
		public decimal Preco { get; set; }
	}
}
