using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaProdutoEController : ControllerBase
    {
        [HttpGet]
        public IActionResult Leitura( ProdutoE_DTO curtida)
        {
            ProdutoE_DAO dao = new ProdutoE_DAO();
            dao.LeituraCurtida(curtida);
            return Ok(curtida);
        }

        [HttpPost]
        public IActionResult Curtida(ProdutoE_DTO curtida)
        {
            ProdutoE_DAO dao = new ProdutoE_DAO();
            dao.CurtidasProdutoE (curtida);
            return Ok(curtida);
        }

    }
}
