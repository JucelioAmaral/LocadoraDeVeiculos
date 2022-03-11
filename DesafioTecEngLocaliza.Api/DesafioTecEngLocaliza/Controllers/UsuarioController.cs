using DesafioTecEngLocaliza.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(UsuarioDto user)
        {
            return null;
        }
    }
}
