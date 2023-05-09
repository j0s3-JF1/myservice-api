using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoE_Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Listar()
        {
            ProdutoE_DAO dao = new ProdutoE_DAO();
            var Produto = dao.ListarProdutoE();
            return Ok(Produto);
        }

        [HttpPost]
        public IActionResult Cadastrar(ProdutoE_DTO produto)
        {
            ProdutoE_DAO dao = new ProdutoE_DAO();
            dao.CadastrarProdutoE(produto);
            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Alterar(ProdutoE_DTO produto)
        {
            ProdutoE_DAO dao = new ProdutoE_DAO();
            dao.AlterarProduto(produto);
            return Ok(produto);
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            ProdutoE_DAO dao = new ProdutoE_DAO();
            dao.DeletarProduto(id);
            return Ok(id);
        }
    }
}
