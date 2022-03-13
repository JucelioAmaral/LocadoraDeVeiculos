using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(MarcaDto marcaDto)
        {
            try
            {
                var existeMarca = await _marcaService.GetMarcaPorNomeAsync(marcaDto.NomeMarca);
                if (existeMarca == null)
                {
                    var marca = await _marcaService.AddMarca(marcaDto);
                    return Ok(marca);
                }
                return BadRequest("Marca já cadastrado.");

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar a marca. Erro: {ex.Message}");
            }
        }
    }
}
