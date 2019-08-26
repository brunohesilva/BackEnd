﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                EstiloRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstiloRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos Estilo = EstiloRepository.BuscarPorId(id);
            if (Estilo == null)
                return NotFound();
            return Ok(Estilo);
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos EstilosBuscado = EstiloRepository.BuscarPorId(estilo.IdEstilo);

                if (EstilosBuscado == null)
                    return NotFound();

                EstiloRepository.Atualizar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}