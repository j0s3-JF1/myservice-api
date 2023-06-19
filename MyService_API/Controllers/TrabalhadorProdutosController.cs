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
        [Route("Trabalhador")]
        public IActionResult ListarTrabalhador( int id )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var TrabalhadorProduto = dao.ProdutosTrabalhador(id);
            return Ok(TrabalhadorProduto);
        }
        [HttpGet]
        [Route("Empresa")]
        public IActionResult ListarEmpresa( int id )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var EmpresaProduto = dao.ProdutosEmpresa(id);
            return Ok(EmpresaProduto);
        }
    }
}
