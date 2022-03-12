using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence.Contratos
{
    public interface IOperadorPersistence
    {
        Task<Operador> GetOperadorPorMatricula(string matricula);
    }
}
