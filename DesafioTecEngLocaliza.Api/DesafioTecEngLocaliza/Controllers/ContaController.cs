using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IContaService _contaService;
        private readonly IClienteService _clienteService;
        private readonly IOperadorService _operadorService;

        public ContaController(IMapper mapper, IContaService contaService, IClienteService clienteService, IOperadorService operadorService)
        {
            _mapper = mapper;
            _contaService = contaService;
            _clienteService = clienteService;
            _operadorService = operadorService;
        }

        [HttpPost("Registra")]
        public async Task<IActionResult> Registra(UsuarioDto usuarioLogin)
        {
            try
            {
                var usuario = await _contaService.AddUsuario(usuarioLogin);
                if (usuario == null) return BadRequest("Usuário já cadastrado");

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
                var loginCliente = await _clienteService.ValidaLoginClienteAsync(clienteLogin.CPF, clienteLogin.Senha);
                if (loginCliente == null) return Unauthorized("Login ou senha inválidos.");

                return Ok(_mapper.Map<ClienteDto>(loginCliente));                             
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar fazer login com o Cliente informado. Erro: {ex.Message}");                
            }
        }

        [HttpPost("Login/Operador")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginOperador(LoginOperadorDto operadorLogin)
        {
            try
            {
                var loginOperador = await _operadorService.ValidaLoginOperadorAsync(operadorLogin.Matricula, operadorLogin.Senha);
                if (loginOperador == null) return Unauthorized("Login ou senha inválidos.");
                
                return Ok(_mapper.Map<OperadorDto>(loginOperador));
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar fazer login com o operador informado. Erro: {ex.Message}");
            }
        }
    }
}
