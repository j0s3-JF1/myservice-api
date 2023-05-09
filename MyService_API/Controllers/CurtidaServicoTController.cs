using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaServicoTController : ControllerBase
    {
        [HttpGet]
        public IActionResult Leitura( ServicoT_DTO curtida)
        {
            ServicoT_DAO dao = new ServicoT_DAO();
            dao.LeituraCurtida(curtida);
            return Ok(curtida);
        }

        [HttpPost]
        public IActionResult Curtida(ServicoT_DTO curtida)
        {
            ServicoT_DAO dao = new ServicoT_DAO();
            dao.CadastrarServicoT(curtida);
            return Ok(curtida);
        }
    }
}
