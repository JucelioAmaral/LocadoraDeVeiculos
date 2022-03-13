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
    public class ModeloPersistence : IModeloPersistence
    {
        private readonly DatabaseContext _context;

        public ModeloPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Modelo> GetModeloPorNomeModelo(string modelo)
        {
            IQueryable<Modelo> query = _context.tblModelo;
            query = query.AsNoTracking().OrderBy(m => m.NomeModelo).Where(m => m.NomeModelo == modelo);
            return query.FirstOrDefault();
        }
    }
}
