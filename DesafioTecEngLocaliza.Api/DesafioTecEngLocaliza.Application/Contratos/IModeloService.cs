using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application.Contratos
{
    public interface IModeloService
    {
        Task<ModeloDto> AddModelo(ModeloDto model);
        Task<Modelo> GetModeloPorNomeModeloAsync(string modelo);
    }
}
