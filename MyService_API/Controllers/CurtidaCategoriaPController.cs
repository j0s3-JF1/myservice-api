using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaCategoriaPController : ControllerBase
    {
        [HttpGet]
        public IActionResult Leitura( CategoriaP_DTO curtida)
        {
            CategoriaP_DAO dao = new CategoriaP_DAO();
            dao.LeituraCurtida(curtida);
            return Ok(curtida);
        }

        [HttpPost]
        public IActionResult Curtida ( CategoriaP_DTO curtida)
        {
            CategoriaP_DAO dao =new CategoriaP_DAO();
            dao.CurtidasCategoriaP(curtida);
            return Ok(curtida);
        }
    }
}
