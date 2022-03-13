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
    public class MarcaPersistence : IMarcaPersistence
    {
        private readonly DatabaseContext _context;

        public MarcaPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Marca> GetMarcaPorNomeMarca(string marca)
        {
            IQueryable<Marca> query = _context.tblMarca;
            query = query.AsNoTracking().OrderBy(m => m.NomeMarca).Where(m => m.NomeMarca == marca);
            return query.FirstOrDefault();
        }
    }
}
