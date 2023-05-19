using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoTrabalhadorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Lista( int id)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.Servico(id);
            return Ok(id);
        }
    }
}
