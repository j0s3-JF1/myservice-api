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

        [HttpGet]
        [Route("Trabalhador")]
        public IActionResult ServicoTrabalhador( string categoria )
        {
            var dao = new CategoriaS_DAO();
            var servicos = dao.ListaServicoTrabalhador(categoria);
            return Ok(servicos);
        }

        [HttpGet]
        [Route("Empresa")]
        public IActionResult ServicoEmpresa( string categoria)
        {
            var dao = new CategoriaS_DAO();
            var servicos = dao.ListaServicoEmpresa(categoria);
            return Ok(servicos);
        }
    }
}
