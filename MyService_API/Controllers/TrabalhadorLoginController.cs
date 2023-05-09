using Microsoft.AspNetCore.Mvc;
using MyService_API.DTO;
using MyService_API.DAO;
namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorLoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult TrabalhadorLogin( TrabalhadorDTO login)
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.LoginTrabalhador(login);
            return Ok(login);
        }
    }
}
