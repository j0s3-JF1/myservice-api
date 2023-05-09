using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaCategoriaSController : ControllerBase
    {
        [HttpGet]
        public IActionResult Leitura( CategoriaS_DTO curtida)
        {
            CategoriaS_DAO dao = new CategoriaS_DAO();
            dao.LeituraCurtida(curtida);
            return Ok(curtida);
        }

        [HttpPost]
        public IActionResult Curtida(CategoriaS_DTO curtida)
        {
            CategoriaS_DAO dao = new CategoriaS_DAO();
            dao.CurtidasCategoriaS(curtida);
            return Ok(curtida);
        }
    }
}
