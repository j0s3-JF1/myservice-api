using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaS_Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            CategoriaS_DAO dao = new CategoriaS_DAO();
            var Categoria = dao.ListarCategoriaS();
            return Ok(Categoria);
        }
    }
}
