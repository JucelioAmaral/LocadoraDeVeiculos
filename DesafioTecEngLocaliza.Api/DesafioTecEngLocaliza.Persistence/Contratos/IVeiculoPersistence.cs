using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence.Contratos
{
    public interface IVeiculoPersistence
    {
        Task<Veiculo> GetVeiculoPorPlaca(string placa);
    }
}
