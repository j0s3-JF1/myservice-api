using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrabalhadorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var Trabalhador = dao.ListarTrabalhador();
            return Ok(Trabalhador);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ListaPorID( int id)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var Trabalhador = dao.ListarTrabalhadorPorID(id);
            return Ok(Trabalhador);
        }

        [HttpGet]
        [Route("Acesso")]
        public IActionResult Acesso( int id)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var Acesso = dao.Access(id);
            return Ok(Acesso);
        }

        [HttpPut]
        public IActionResult Alterar( TrabalhadorDTO work)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.AlerarTrabalho(work);
            return Ok(work);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar( int id )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.DeletarTrabalhador(id);
            return Ok(id);
        }
    }
}
