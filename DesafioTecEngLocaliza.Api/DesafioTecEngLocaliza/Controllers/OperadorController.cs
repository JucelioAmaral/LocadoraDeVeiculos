using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperadorController : ControllerBase
    {
        private readonly IOperadorService _operadorService;

        public OperadorController(IOperadorService operadorService)
        {
            _operadorService = operadorService;
        }
        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(OperadorDto operadorDto)
        {
            try
            {
                var existeOperador = await _operadorService.GetOperadorPorMatriculaAsync(operadorDto.Matricula);
                if (existeOperador == null)
                {
                    var cliente = await _operadorService.AddOperador(operadorDto);
                    return Ok(cliente);
                }
                return BadRequest("Operador já cadastrado.");

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar o operador. Erro: {ex.Message}");
            }
        }
    }
}
