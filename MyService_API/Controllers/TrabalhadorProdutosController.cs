using MyService_API.DTO;
using MyService_API.DAO;
using Microsoft.AspNetCore.Mvc;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    public class TrabalhadorProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar( int id )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.ProdutosTrabalhador(id);
            return Ok(id);
        }
    }
}
