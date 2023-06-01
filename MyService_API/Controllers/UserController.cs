using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            UserDAO dao = new UserDAO();
            var User = dao.ListarUsuario();
            return Ok(User);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult UsuarioPorID( int id )
        {
            UserDAO dao = new UserDAO();
            var usuario = dao.ListarPorID(id);
            return Ok(usuario);
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
