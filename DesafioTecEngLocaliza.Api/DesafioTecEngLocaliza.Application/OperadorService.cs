using AutoMapper;
using DesafioTecEngLocaliza.Application.Contratos;
using DesafioTecEngLocaliza.Application.DTO;
using DesafioTecEngLocaliza.Domain;
using DesafioTecEngLocaliza.Persistence.Contratos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecEngLocaliza.Application
{
    public class OperadorService : IOperadorService
    {
        private readonly IMapper _mapper;
        private readonly IGeralPersistence _geralPersistence;
        private readonly IOperadorPersistence _operadorPersistence;

        public OperadorService(IMapper mapper, IGeralPersistence geralPersistence, IOperadorPersistence operadorPersistence)
        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _operadorPersistence = operadorPersistence;
        }

        public async Task<OperadorDto> AddOperador(OperadorDto model)
        {
            var operador = _mapper.Map<Operador>(model);
            _geralPersistence.Add<Operador>(operador);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<OperadorDto>(operador);
            }
            return null;
        }

        public async Task<Operador> GetOperadorPorMatriculaAsync(string matricula)
        {
            var operador = await _operadorPersistence.GetOperadorPorMatricula(matricula);
            if (operador != null)
            {
                return _mapper.Map<Operador>(operador);
            }
            return null;
        }

        public async Task<Operador> ValidaLoginOperadorAsync(string matricula, string senha)
        {
            var usuario = await _operadorPersistence.GetLoginOperadorTblUsuario(matricula);
            if (usuario != null)
            {
                if (matricula == usuario.Login && senha == usuario.Senha)
                {
                    var operador = await _operadorPersistence.GetOperadorPorMatricula(matricula);
                    if (operador != null)
                    {
                        return _mapper.Map<Operador>(operador);
                    }
                    return null;
                }
            }
            return null;
        }
    }
}
