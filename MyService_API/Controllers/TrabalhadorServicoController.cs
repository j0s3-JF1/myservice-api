using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorServicoController: ControllerBase
    {
        [HttpGet]
        [Route("Trabalhador")]
        public IActionResult ListaTrabalhador( int id)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var servico = dao.ServicoTrabalhador(id);
            return Ok(servico);
        }

        [HttpGet]
        [Route("Empresa")]
        public IActionResult ListaEmpresa(int id)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            var servico = dao.ServicoEmpresa(id);
            return Ok(servico);
        }
    }
}
