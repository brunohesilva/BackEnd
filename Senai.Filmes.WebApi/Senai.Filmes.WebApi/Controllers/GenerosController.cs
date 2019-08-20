using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        List<GeneroDomain> generos = new List<GeneroDomain>()
        {
            new GeneroDomain { IdGenero = 1, Nome = "Fantasia" }
            ,new GeneroDomain { IdGenero = 2, Nome = "Drama"  }
        };
    }
}