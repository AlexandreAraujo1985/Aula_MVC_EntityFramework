using Microsoft.AspNetCore.Mvc;

namespace Aula_MVC_EntityFramework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        [HttpGet]
        public IActionResult ListarFornecedores()
        {
            return Ok(new[] { new { Id = 1, Nome = "Bic" } });
        }

        [HttpGet("{id}")]
        public IActionResult ListarFornecedores(int id)
        {
            return Ok(new[] { new { Id = 1, Nome = "Bic" } });
        }

        [HttpPost]
        public IActionResult IncluirFornecedores([FromBody] object obj)
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
