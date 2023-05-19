using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaInstagramController : ControllerBase
    {
        [HttpPut]
        public IActionResult Instagram( EmpresaDTO insta )
        {
            EmpresaDAO dao = new EmpresaDAO();
            dao.Instagram(insta);
            return Ok(insta);
        }
    }
}
