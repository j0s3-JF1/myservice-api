using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            EmpresaDAO dao = new EmpresaDAO();
            var Empresa = dao.ListarEmpresa();
            return Ok(Empresa);
        }
        

        [HttpPost]
        public IActionResult Cadastrar( EmpresaDTO enterprise)
        {
            EmpresaDAO dao = new EmpresaDAO();
            dao.CadastroEmpresa(enterprise);
            return Ok(enterprise);
        }

        [HttpPut]
        public IActionResult Alterar( EmpresaDTO enterprise)
        {
            EmpresaDAO dao = new EmpresaDAO();
            dao.AlterarEmpresa(enterprise); 
            return Ok(enterprise);
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            EmpresaDAO dao = new EmpresaDAO();
            dao.DeletarEmpresa(id);
            return Ok(id);
        }
    }
}
