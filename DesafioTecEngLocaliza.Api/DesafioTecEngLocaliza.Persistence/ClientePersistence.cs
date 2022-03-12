using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contexto;
using DesafioTecEngLocaliza.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence
{
    public class ClientePersistence : IClientePersistence
    {
        private readonly DatabaseContext _context;

        public ClientePersistence(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetClientePorCPF(string cpf)
        {
            IQueryable<Cliente> query = _context.tblCliente;
            query = query.AsNoTracking().OrderBy(c => c.CPF).Where(c => c.CPF == cpf);
            return query.FirstOrDefault();
        }
    }
}
