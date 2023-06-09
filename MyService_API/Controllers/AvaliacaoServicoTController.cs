﻿using Microsoft.AspNetCore.Mvc;
using MyService_API.DAO;
using MyService_API.DTO;

namespace MyService_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoServicoTController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult Comentario(int id)
        {
            AvaliacaoServicoTDAO dao = new AvaliacaoServicoTDAO();
            var avaliacao = dao.ListaDeComentario(id);
            return Ok(avaliacao);
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult Listar(int id)
        {
            AvaliacaoServicoTDAO dao = new AvaliacaoServicoTDAO();
            var avaliacao = dao.Listar(id);
            return Ok(avaliacao);
        }

        [HttpPost]
        public IActionResult Avaliacao(AvaliacaoServicoTDTO avaliacao)
        {
            AvaliacaoServicoTDAO dao = new AvaliacaoServicoTDAO();
            dao.AvaliacaoServicoT(avaliacao);
            return Ok(avaliacao);
        }
    }
}
