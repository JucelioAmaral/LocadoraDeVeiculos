using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence.Contratos
{
    public interface IGeralPersistence
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
