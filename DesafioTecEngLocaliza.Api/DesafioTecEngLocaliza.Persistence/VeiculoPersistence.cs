using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contexto;
using DesafioTecEngLocaliza.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence
{
    public class VeiculoPersistence : IVeiculoPersistence
    {
        private readonly DatabaseContext _context;

        public VeiculoPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Veiculo> GetVeiculoPorPlaca(string placa)
        {
            IQueryable<Veiculo> query = _context.tblVeiculo;
            query = query.AsNoTracking().OrderBy(v => v.Placa).Where(v => v.Placa == placa);
            return query.FirstOrDefault();
        }
    }
}
