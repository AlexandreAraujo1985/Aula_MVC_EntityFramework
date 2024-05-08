using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Aula_MVC_EntityFramework.MVC.Custom
{
	public class EmailTagHelper : TagHelper
	{
		private const string DominioEmail = "fiap.com";

		public string MailTo { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";

			var endereco = string.Concat(MailTo, "@", DominioEmail);
			output.Attributes.SetAttribute("href", $"mailto:{endereco}");
			output.Content.SetContent(endereco);
		}
	}
}
