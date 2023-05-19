using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabalhadorInstagramController : ControllerBase
    {
        [HttpPut]
        public IActionResult Listar( TrabalhadorDTO insta )
        {
            TrabalhadorDAO dao = new TrabalhadorDAO();
            dao.Instagram( insta );
            return Ok( insta );
        }
    }
}
