using DesafioTecEngLocaliza.Application.DTO;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application.Contratos
{
    public interface IContaService
    {
        Task<UsuarioDto> AddUsuario(UsuarioDto model);
        Task<Usuario> ValidaLoginAsync(string login);
    }
}
