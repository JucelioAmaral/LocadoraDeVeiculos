using AutoMapper;
using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application
{
    public class MarcaService : IMarcaService
    {
        private readonly IMapper _mapper;
        private readonly IGeralPersistence _geralPersistence;
        private readonly IMarcaPersistence _marcaPersistence;

        public MarcaService(IMapper mapper, IGeralPersistence geralPersistence, IMarcaPersistence marcaPersistence)
        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _marcaPersistence = marcaPersistence;
        }
        public async Task<MarcaDto> AddMarca(MarcaDto model)
        {
            var marcaRetorno = _mapper.Map<Marca>(model);
            _geralPersistence.Add<Marca>(marcaRetorno);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<MarcaDto>(marcaRetorno);
            }
            return null;
        }

        public async Task<Marca> GetMarcaPorNomeAsync(string marca)
        {
            var marcaRetorno = await _marcaPersistence.GetMarcaPorNomeMarca(marca);
            if (marcaRetorno != null)
            {
                return _mapper.Map<Marca>(marcaRetorno);
            }
            return null;
        }
    }
}
