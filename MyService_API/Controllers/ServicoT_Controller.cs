using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicoT_Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            ServicoT_DAO dao = new ServicoT_DAO();
            var Produto = dao.ListarServicoT();
            return Ok(Produto);
        }

        [HttpPost]
        public IActionResult Cadastrar(ServicoT_DTO produto)
        {
            ServicoT_DAO dao = new ServicoT_DAO();
            dao.CadastrarServicoT(produto);
            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Alterar(ServicoT_DTO produto)
        {
            ServicoT_DAO dao = new ServicoT_DAO();
            dao.AlterarSevico(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar( int id)
        {
            ServicoT_DAO dao = new ServicoT_DAO();
            dao.DeletarServico(id);
            return Ok(id);
        }
    }
}
