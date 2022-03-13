using DesafioTecEngLocaliza.Application.DTO;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application.Contratos
{
    public interface IClienteService
    {
        Task<ClienteDto> AddCliente(ClienteDto model);
        Task<Cliente> GetClientePorCpfAsync(string CPF);
        Task<Cliente> ValidaLoginClienteAsync(string CPF, string senha);
    }
}
