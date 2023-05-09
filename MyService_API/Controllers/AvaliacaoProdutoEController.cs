using MyService_API.DTO;
using MyService_API.DAO;
using Microsoft.AspNetCore.Mvc;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoProdutoEController : ControllerBase
    {
        [HttpPost]
        public IActionResult Avaliacao( AvaliacaoProdutoEDTO avaliacao)
        {
            AvaliacaoProdutoEDAO dao = new AvaliacaoProdutoEDAO();
            dao.AvaliacaoProdutoE(avaliacao);
            return Ok(avaliacao);
        }
    }
}
