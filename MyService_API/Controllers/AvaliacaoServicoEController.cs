using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoServicoEController : ControllerBase
    {
        [HttpGet]
        public IActionResult Comentario(int id)
        {
            AvaliacaoServicoEDAO dao = new AvaliacaoServicoEDAO();
            var avaliacao = dao.ListaDeComentario(id);
            return Ok(avaliacao);
        }

        [HttpPost]
        public IActionResult Avaliacao( AvaliacaoServicoEDTO avaliacao)
        {
            AvaliacaoServicoEDAO dao = new AvaliacaoServicoEDAO();
            dao.AvaliacaoServicoE(avaliacao);
            return Ok(avaliacao);
        }
    }
}
