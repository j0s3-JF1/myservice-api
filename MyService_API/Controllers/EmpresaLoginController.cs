using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaLoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmpresaLogin( EmpresaDTO login)
        {
            EmpresaDAO dao = new EmpresaDAO();
            dao.LoginEmpresa(login);
            return Ok(login);
        }
    }
}
