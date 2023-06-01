using MyService_API.DTO;
using MyService_API.DAO;
using Microsoft.AspNetCore.Mvc;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoProdutoEController : ControllerBase
    {
        [HttpGet]
        public IActionResult Comentario( int id )
        {
            AvaliacaoProdutoEDAO dao = new AvaliacaoProdutoEDAO();
            var avaliacao = dao.ListaDeComentario(id);
            return Ok(avaliacao);
        }
        [HttpPost]
        public IActionResult Avaliacao( AvaliacaoProdutoEDTO avaliacao)
        {
            AvaliacaoProdutoEDAO dao = new AvaliacaoProdutoEDAO();
            dao.AvaliacaoProdutoE(avaliacao);
            return Ok(avaliacao);
        }
    }
}
