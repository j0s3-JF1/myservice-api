using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var Trabalhador = dao.ListarTrabalhador();
            return Ok(Trabalhador);
        }

        [HttpPost]
        public IActionResult Cadastrar( TrabalhadorDTO work )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.CadastroTrabalhador(work);
            return Ok(work);
        }

        [HttpPut]
        public IActionResult Alterar( TrabalhadorDTO work)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.AlerarTrabalho(work);
            return Ok(work);
        }

        [HttpDelete]
        public IActionResult Deletar( int id )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.DeletarTrabalhador(id);
            return Ok(id);
        }
    }
}
