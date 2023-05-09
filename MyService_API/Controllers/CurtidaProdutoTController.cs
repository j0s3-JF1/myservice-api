using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaProdutoTController : ControllerBase
    {
        [HttpGet]
        public IActionResult Leitura( ProdutoT_DTO curtida)
        {
            ProdutoT_DAO dao = new ProdutoT_DAO();
            dao.LeituraCurtida(curtida);
            return Ok(curtida);
        }

        [HttpPost]
        public IActionResult Curtida(ProdutoT_DTO curtida)
        {
            ProdutoT_DAO dao = new ProdutoT_DAO();
            dao.CurtidasProdutoT(curtida);
            return Ok(curtida);
        }
    }
}
