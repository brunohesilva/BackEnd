using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>()
               {
               new EstiloDomain { IdEstilo = 1,   Nome = "Rock"}
               ,new EstiloDomain { IdEstilo = 2,  Nome = "Pop"}
        };

        EstiloRepository EstiloRepository = new EstiloRepository
            ();

        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            return EstiloRepository.Listar();
        }
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            EstiloDomain Estilo = EstiloRepository.BucarPorId(Id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }
        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estilosDomain)
        {
            EstiloRepository.Cadastrar(estilosDomain);
            return Ok();
        }
        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }
    }
}