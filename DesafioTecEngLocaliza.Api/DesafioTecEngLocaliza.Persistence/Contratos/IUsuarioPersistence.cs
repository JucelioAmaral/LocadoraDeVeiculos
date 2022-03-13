using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence.Contratos
{
    public interface IUsuarioPersistence
    {
        Task<Usuario> GetLoginPorLogin(string login);
    }
}
