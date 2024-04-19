namespace Aula_MVC_EntityFramework.MVC
{
	public class Paginador<T> : List<T>
	{
		public int PaginaInicial { get; private set; }
		public int TotalPaginas { get; private set; }

		public Paginador(List<T> itens, int contador, int paginaInicial, int totalPaginas)
		{
			PaginaInicial = paginaInicial;
			TotalPaginas = (int)Math.Ceiling(contador / (decimal)totalPaginas);

			AddRange(itens);
		}

		public bool TemPaginaAnterior => PaginaInicial > 1;
		public bool TemProximaPagina => PaginaInicial < TotalPaginas;

		public static Paginador<T> CriarPaginacao(IQueryable<T> fonte, int paginaInicial, int totalPaginas)
		{
			var contador = fonte.Count();
			var itens = fonte.Skip((paginaInicial - 1) * totalPaginas).Take(totalPaginas).ToList();

			return new Paginador<T>(itens, contador, paginaInicial, totalPaginas);
		}
	}
}