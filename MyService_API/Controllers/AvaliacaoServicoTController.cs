using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoServicoTController : ControllerBase
    {
        [HttpGet]
        public IActionResult Comentario(int id)
        {
            AvaliacaoServicoTDAO dao = new AvaliacaoServicoTDAO();
            dao.ListaDeComentario(id);
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Avaliacao(AvaliacaoServicoTDTO avaliacao)
        {
            AvaliacaoServicoTDAO dao = new AvaliacaoServicoTDAO();
            dao.AvaliacaoServicoT(avaliacao);
            return Ok(avaliacao);
        }
    }
}
