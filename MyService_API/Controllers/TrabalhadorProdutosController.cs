using MyService_API.DTO;
using MyService_API.DAO;
using Microsoft.AspNetCore.Mvc;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar( int id )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var TrabalhadorProduto = dao.Produtos(id);
            return Ok(TrabalhadorProduto);
        }
    }
}
