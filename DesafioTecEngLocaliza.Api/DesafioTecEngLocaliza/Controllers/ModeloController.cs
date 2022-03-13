using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.Dtos;
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
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;

        public ModeloController(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(ModeloDto modeloDto)
        {
            try
            {
                var existeModelo = await _modeloService.GetModeloPorNomeModeloAsync(modeloDto.NomeModelo);
                if (existeModelo == null)
                {
                    var modelo = await _modeloService.AddModelo(modeloDto);
                    return Ok(modelo);
                }
                return BadRequest("Modelo já cadastrado.");

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar o modelo. Erro: {ex.Message}");
            }
        }
    }
}
