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
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IGeralPersistence _geralPersistence;
        private readonly IClientePersistence _clientePersistence;

        public ClienteService(IMapper mapper, IGeralPersistence geralPersistence, IClientePersistence clientePersistence)
        {
            _mapper = mapper;
            _geralPersistence = geralPersistence;
            _clientePersistence = clientePersistence;
        }

        public async Task<ClienteDto> AddCliente(ClienteDto model)
        {
            var cliente = _mapper.Map<Cliente>(model);
            _geralPersistence.Add<Cliente>(cliente);
            if (await _geralPersistence.SaveChangesAsync())
            {
                return _mapper.Map<ClienteDto>(cliente);
            }
            return null;
        }

        public async Task<Cliente> GetClientePorCpfAsync(string cpf)
        {
            var cliente = await _clientePersistence.GetClientePorCPF(cpf);
            if (cliente != null)
            {
                return _mapper.Map<Cliente>(cliente);
            }
            return null;
        }
    }
}
