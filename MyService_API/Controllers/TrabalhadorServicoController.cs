using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorServicoController: ControllerBase
    {
        [HttpGet]
        public IActionResult Lista( int id)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var servico = dao.Servico(id);
            return Ok(servico);
        }
    }
}
