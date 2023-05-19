using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;


namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaProdutoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Lista( int id)
        {
            EmpresaDAO dao = new EmpresaDAO();
            dao.Produtos(id);
            return Ok(id);
        }
    }
}
