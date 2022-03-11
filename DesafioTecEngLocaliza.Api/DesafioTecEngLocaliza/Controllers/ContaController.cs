using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [AllowAnonymous]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(UsuarioDto usuarioLogin)
        {
            try
            {
                var usuario = await _contaService.AddUsuario(usuarioLogin);
                if (usuario == null) return NoContent();

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,$"Erro ao tentar registrar usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login/Cliente")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginCliente(LoginClienteDto clienteLogin)
        {
            try
            {
                return null;
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar fazer login com o Cliente informado. Erro: {ex.Message}");                
            }
        }

        [HttpPost("Login/Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginOperador(LoginOperadorDto clienteLogin)
        {
            try
            {
                return null;
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar fazer login com o operador informado. Erro: {ex.Message}");
            }
        }
    }
}
