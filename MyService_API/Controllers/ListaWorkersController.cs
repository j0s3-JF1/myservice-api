using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaWorkersController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListaWorkers()
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var Trabalhador = dao.ListarTrabalhador();
            return Ok(Trabalhador);
        }

    }
}
