using AutoMapper;
using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioPersistence _usuarioPersistence;

        public UsuarioService(IMapper mapper, IUsuarioPersistence usuarioPersistence)
        {
            _mapper = mapper;
            _usuarioPersistence = usuarioPersistence;
        }
        public async Task<Usuario> GetLoginAsync(string login)
        {
            var usuario = await _usuarioPersistence.GetLoginPorLogin(login);
            if (usuario != null)
            {
                return _mapper.Map<Usuario>(usuario);
            }
            return null;
        }
    }
}
