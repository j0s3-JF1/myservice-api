using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;
using System.Xml.Linq;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            UserDAO dao = new UserDAO();
            var User = dao.ListarUsuario();
            return Ok(User);
        }

        [HttpPost]
        public IActionResult Cadastrar(UserDTO user)
        {
            UserDAO dao = new UserDAO();
            dao.CadastroUsuario(user);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Alterar(UserDTO user)
        {
            UserDAO dao = new UserDAO();
            dao.AlterarUsuario(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UserDAO dao = new UserDAO();
            dao.DeletarUsuario(id);
            return Ok(id);
        }
    }
}
