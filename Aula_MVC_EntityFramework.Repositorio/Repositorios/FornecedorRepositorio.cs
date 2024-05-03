using Aula_MVC_EntityFramework.Repositorio.Contexto;
using Aula_MVC_EntityFramework.Repositorio.Entidades;
using Aula_MVC_EntityFramework.Repositorio.Repositorios.DTOs;

namespace Aula_MVC_EntityFramework.Repositorio.Repositorios
{
    public class FornecedorRepositorio : RepositorioBase<Fornecedor>
    {
        public FornecedorRepositorio(ProdutoContext produtoContext) : base(produtoContext)
        {
        }

        public List<FornedorDTO> AgruparDadosProdutosFornecedor()
        {
            var dadosAgrupadosProdutosFornecedor = _produtoContext.Fornecedores.ToList()
                                                    .GroupBy(x =>
                                                    {
                                                        return new { x.Nome, x.DataCadastro };
                                                    }).Select(x =>
                                                    {
                                                        return new FornedorDTO
                                                        {
                                                            Nome = x.Key.Nome,
                                                            DataCadastro = x.Key.DataCadastro.ToString("dd/MM/yyyy"),
                                                            Total = x.Count()
                                                        };
                                                    });

            return dadosAgrupadosProdutosFornecedor.ToList();
        }
    }
}
