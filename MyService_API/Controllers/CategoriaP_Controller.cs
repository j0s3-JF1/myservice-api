using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaP_Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            CategoriaP_DAO dao = new CategoriaP_DAO();
            var Categoria = dao.ListarCategoriaP();
            return Ok(Categoria);
        }
    }
}
