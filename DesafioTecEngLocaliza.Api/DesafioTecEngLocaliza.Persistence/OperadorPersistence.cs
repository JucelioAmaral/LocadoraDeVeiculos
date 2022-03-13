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
    public class OperadorPersistence : IOperadorPersistence
    {
        private readonly DatabaseContext _context;

        public OperadorPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Operador> GetOperadorPorMatricula(string matricula)
        {
            IQueryable<Operador> query = _context.tblOperador;
            query = query.AsNoTracking().OrderBy(o => o.Matricula).Where(o => o.Matricula == matricula);
            return query.FirstOrDefault();
        }

        public async Task<Usuario> GetLoginOperadorTblUsuario(string matricula)
        {
            IQueryable<Usuario> query = _context.tblUsuario;
            query = query.AsNoTracking().OrderBy(u => u.Login).Where(u => u.Login == matricula);
            return query.FirstOrDefault();
        }
    }
}
