using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoE_Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            ServicoE_DAO dao = new ServicoE_DAO();
            var Produto = dao.ListarServicoE();
            return Ok(Produto);
        }

        [HttpPost]
        public IActionResult Cadastrar(ServicoE_DTO produto)
        {
            ServicoE_DAO dao = new ServicoE_DAO();
            dao.CadastrarServicoE(produto);
            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Alterar( ServicoE_DTO produto)
        {
            ServicoE_DAO dao = new ServicoE_DAO();
            dao.AlterarServico(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar( int id)
        {
            ServicoE_DAO dao = new ServicoE_DAO();
            dao.DeletarServico(id);
            return Ok(id);
        }
    }
}
