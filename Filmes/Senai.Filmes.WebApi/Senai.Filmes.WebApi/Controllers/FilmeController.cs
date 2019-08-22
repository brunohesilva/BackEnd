using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        FilmeRepository FilmeRepository = new FilmeRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeRepository filme)
        {
            try
            {
                FilmeRepository.Cadastrar(filme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }

        public IActionResult BuscarPorId(int id)
        {
            FilmeRepository Filme = FilmeRepository.BuscarPorId(id);
            if (Filme == null)
            {
                return NotFound();
            }
            return Ok(Filme);
        }
    }
}