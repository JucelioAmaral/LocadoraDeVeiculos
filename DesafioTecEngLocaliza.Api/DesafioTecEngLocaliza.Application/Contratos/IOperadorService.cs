using DesafioTecEngLocaliza.Application.DTO;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application.Contratos
{
    public interface IOperadorService
    {
        Task<OperadorDto> AddOperador(OperadorDto model);
        Task<Operador> GetOperadorPorMatriculaAsync(string matricula);
        Task<Operador> ValidaLoginOperadorAsync(string matricula, string senha);
    }
}
