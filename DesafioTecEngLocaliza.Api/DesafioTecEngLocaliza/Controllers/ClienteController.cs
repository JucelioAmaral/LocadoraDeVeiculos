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
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(ClienteDto clienteDto)
        {
            try
            {
                var existeCliente = await _clienteService.GetClientePorCpfAsync(clienteDto.CPF);
                if (existeCliente == null)
                {
                    var cliente = await _clienteService.AddCliente(clienteDto);
                    return Ok(cliente);
                }
                return BadRequest("Cliente já cadastrado.");

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar o cliente. Erro: {ex.Message}");
            }
        }
    }
}
