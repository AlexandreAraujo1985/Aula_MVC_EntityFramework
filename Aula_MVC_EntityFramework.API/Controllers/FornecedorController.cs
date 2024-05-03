using Microsoft.AspNetCore.Mvc;
using Aula_MVC_EntityFramework.Repositorio.Repositorios;
using Newtonsoft.Json;
using Aula_MVC_EntityFramework.Repositorio.Repositorios.DTOs;
using Aula_MVC_EntityFramework.API.Model;

namespace Aula_MVC_EntityFramework.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private FornecedorRepositorio fornecedorRepositorio;

        public FornecedorController()
        {
            fornecedorRepositorio = new FornecedorRepositorio(new Repositorio.Contexto.ProdutoContext());
        }

        [HttpGet]
        public IActionResult ListarFornecedores()
        {
            var client = new HttpClient();

            var result = client.GetAsync("https://jsonplaceholder.typicode.com/todos/1").Result.Content.ReadAsStringAsync().Result;
            
            var obj = JsonConvert.DeserializeObject<Livro>(result);

            var fornecedores = fornecedorRepositorio.ListarTodos();

            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public IActionResult ListarFornecedores(int id)
        {
            return Ok(new[] { new { Id = 1, Nome = "Bic" } });
        }

        [HttpPost]
        public IActionResult IncluirFornecedores([FromBody] FornecedorModel fornecedorModel)
        {
            return Ok(new[] { new { Id = 1, Nome = "Bic" } });
        }

        [HttpPut]
        public IActionResult AlterarFornecedores(int id)
        {
            return Ok(new[] { new { Id = 1, Nome = "Bic" } });
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirFornecedores(int id)
        {
            return Ok(new[] { new { Id = 1, Nome = "Bic" } });
        }
    }
}
