using System.Globalization;

namespace Aula_MVC_EntityFramework.MVC
{
	public static class Utils
	{
		public static string FormatarData(this DateTime data)
		{
			return data.ToString("dd/MM/yyyy");
		}

		//public static string FormatarMoeda(this decimal valor)
		//{
		//	return string.Format(CultureInfo.GetCultureInfo("pt-BR") + "{C:0}", valor);
		//}
	}
}
