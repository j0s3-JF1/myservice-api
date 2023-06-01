using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaServicoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Lista( int id )
        {
            EmpresaDAO dao = new EmpresaDAO();
            var servico = dao.Servico(id);
            return Ok(servico);
        }
    }
}
