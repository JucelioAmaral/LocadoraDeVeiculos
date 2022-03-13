using AutoMapper;
using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Domain.Enum;
using DesafioTecEngLocaliza.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IGeralPersistence _geralPersistence;
        private readonly IVeiculoPersistence _veiculoPersistence;

        public VeiculoService(IMapper mapper, IGeralPersistence geralPersistence, IVeiculoPersistence veiculoPersistence)
        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _veiculoPersistence = veiculoPersistence;
        }

        public async Task<VeiculoDto> AddVeiculo(int IdMarca, int IdModelo,VeiculoDto model)
        {

            var veiculo = _mapper.Map<Veiculo>(model);
            veiculo.MarcaId = IdMarca;
            veiculo.ModeloId = IdModelo;
            _geralPersistence.Add<Veiculo>(veiculo);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<VeiculoDto>(veiculo);
            }
            return null;
        }

        public async Task<Veiculo> GetVeiculoPorPlacaAsync(string placa)
        {
            var veiculoRetorno = await _veiculoPersistence.GetVeiculoPorPlaca(placa);
            if (veiculoRetorno != null)
            {
                return _mapper.Map<Veiculo>(veiculoRetorno);
            }
            return null;
        }
    }
}
