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
    public class ModeloService : IModeloService
    {
        private readonly IMapper _mapper;
        private readonly IGeralPersistence _geralPersistence;
        private readonly IModeloPersistence _modeloPersistence;

        public ModeloService(IMapper mapper, IGeralPersistence geralPersistence, IModeloPersistence modeloPersistence)
        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _modeloPersistence = modeloPersistence;
        }
        public async Task<ModeloDto> AddModelo(ModeloDto model)
        {
            var modeloRetorno = _mapper.Map<Modelo>(model);
            _geralPersistence.Add<Modelo>(modeloRetorno);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<ModeloDto>(modeloRetorno);
            }
            return null;
        }

        public async Task<Modelo> GetModeloPorNomeModeloAsync(string modelo)
        {
            var modeloRetorno = await _modeloPersistence.GetModeloPorNomeModelo(modelo);
            if (modeloRetorno != null)
            {
                return _mapper.Map<Modelo>(modeloRetorno);
            }
            return null;
        }
    }
}
