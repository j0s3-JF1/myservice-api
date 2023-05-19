using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoT_Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            ProdutoT_DAO dao = new ProdutoT_DAO();
            var Produto = dao.ListarProdutoT();
            return Ok(Produto);
        }

        [HttpPost]
        public IActionResult Cadastrar( ProdutoT_DTO produto)
        {
            ProdutoT_DAO dao = new ProdutoT_DAO();
            dao.CadastrarProdutoT(produto);
            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Alterar( ProdutoT_DTO produto)
        {
            ProdutoT_DAO dao = new ProdutoT_DAO();
            dao.AlterarProduto(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar( int id)
        {
            ProdutoT_DAO dao = new ProdutoT_DAO();
            dao.DeletarProduto(id);
            return Ok(id);
        }
    }
}
