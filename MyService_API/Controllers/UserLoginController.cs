using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult UserLogin(UserDTO login)
        {
            UserDAO dao = new UserDAO();
            dao.LoginUsuario(login);
            return Ok(login);
        }
    }
}
