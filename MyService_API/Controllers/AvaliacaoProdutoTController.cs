using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoProdutoTController : ControllerBase
    {
        [HttpPost]
        public IActionResult Avaliacao( AvaliacaoProdutoTDTO avaliacao )
        {
            AvaliacaoProdutoTDAO dao = new AvaliacaoProdutoTDAO();
            dao.AvaliacaoProdutoT( avaliacao );
            return Ok(avaliacao);
        }
    }
}
