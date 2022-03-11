using AutoMapper;
using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.DTO;
using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application
{
    public class ContaService : IContaService
    {
        private readonly IMapper _mapper;
        private readonly IGeralPersistence _geralPersistence;

        public ContaService(IMapper mapper, IGeralPersistence geralPersistence)
        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
        }

        public async Task<UsuarioDto> AddUsuario(UsuarioDto model)
        {
            var usuario = _mapper.Map<Usuario>(model);
            _geralPersistence.Add<Usuario>(usuario);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<UsuarioDto>(usuario);
            }
            return null;
        }
    }
}
