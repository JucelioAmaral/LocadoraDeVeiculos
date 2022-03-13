using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application.Contratos
{
    public interface IMarcaService
    {
        Task<MarcaDto> AddMarca(MarcaDto model);
        Task<Marca> GetMarcaPorNomeAsync(string marca);
    }
}
