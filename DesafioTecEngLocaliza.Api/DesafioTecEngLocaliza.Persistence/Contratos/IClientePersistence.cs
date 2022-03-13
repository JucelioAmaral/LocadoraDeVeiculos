using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Persistence.Contratos
{
    public interface IClientePersistence
    {
        Task<Cliente> GetClientePorCPF(string cpf);
        Task<Usuario> GetLoginClienteTblUsuario(string CPF);        
    }
}
