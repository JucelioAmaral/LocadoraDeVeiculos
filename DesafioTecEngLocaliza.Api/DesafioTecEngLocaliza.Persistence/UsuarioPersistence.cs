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
    public class UsuarioPersistence : IUsuarioPersistence
    {
        private readonly DatabaseContext _context;

        public UsuarioPersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetLoginPorLogin(string login)
        {
            IQueryable<Usuario> query = _context.tblUsuario;
            query = query.AsNoTracking().OrderBy(u => u.Login).Where(u => u.Login == login);
            return query.FirstOrDefault();
        }
    }
}
