using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contratos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Api
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMarcaPersistence _marcaPersistence;
        private readonly IModeloPersistence _modeloPersistence;

        public VeiculoController(IVeiculoService veiculoService, IMarcaPersistence marcaPersistence, IModeloPersistence modeloPersistence)
        {
            _veiculoService = veiculoService;
            _marcaPersistence = marcaPersistence;
            _modeloPersistence = modeloPersistence;
        }

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(VeiculoDto veiculoDto)
        {
            try
            {
                var existeVeiculo = await _veiculoService.GetVeiculoPorPlacaAsync(veiculoDto.Placa);
                if (existeVeiculo == null)
                {
                    var marcaRetorno = await _marcaPersistence.GetMarcaPorNomeMarca(veiculoDto.Marca.NomeMarca);
                    if (marcaRetorno == null) return BadRequest("Marca não encontrada.");

                    var modeloRetorno = await _modeloPersistence.GetModeloPorNomeModelo(veiculoDto.Modelo.NomeModelo);
                    if (modeloRetorno == null) return BadRequest("Modelo não encontrado.");

                    var veiculo = await _veiculoService.AddVeiculo(marcaRetorno.Id, modeloRetorno.Id, veiculoDto);
                    if (veiculo != null)return Ok(veiculo);
                }
                return BadRequest($"Veículo com a placa {veiculoDto.Placa} já está cadastrado.");

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar o veículo. Erro: {ex.Message}");
            }
        }
    }
}
