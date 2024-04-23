namespace Aula_MVC_EntityFramework.MVC.Models
{
	public class TabelaDadosBaseModel
	{
		public int Id { get; set; }
		public string ActionName { get; set; }
		public Dictionary<string, string> Itens { get; set; }
	}
}
