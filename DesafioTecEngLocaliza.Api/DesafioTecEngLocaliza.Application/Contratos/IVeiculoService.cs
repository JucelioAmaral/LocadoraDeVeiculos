using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application.Contratos
{
    public interface IVeiculoService
    {
        Task<VeiculoDto> AddVeiculo(int IdMarca, int IdModelo, VeiculoDto model);
        Task<Veiculo> GetVeiculoPorPlacaAsync(string placa);
    }
}
