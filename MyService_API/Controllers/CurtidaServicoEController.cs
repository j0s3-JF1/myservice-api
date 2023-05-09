using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaServicoEController : ControllerBase
    {
        [HttpGet]
        public IActionResult Leitura( ServicoE_DTO curtida)
        {
            ServicoE_DAO dao = new ServicoE_DAO();
            dao.LeituraCurtida(curtida);
            return Ok(curtida);
        }

        [HttpPost]
        public IActionResult Curtida(ServicoE_DTO curtida)
        {
            ServicoE_DAO dao = new ServicoE_DAO();
            dao.CurtidasServicoE(curtida);
            return Ok(curtida);
        }
    }
}
