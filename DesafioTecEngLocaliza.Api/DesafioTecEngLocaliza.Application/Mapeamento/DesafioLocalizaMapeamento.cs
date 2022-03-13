using AutoMapper;
using DesafioTecEngLocaliza.Application.DTO;
using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecEngLocaliza.Application.Mapeamento
{
    public class DesafioLocalizaMapeamento : Profile
    {

        public DesafioLocalizaMapeamento()
        {            
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
            CreateMap<Operador, OperadorDto>().ReverseMap();
            CreateMap<Marca, MarcaDto>().ReverseMap();
        }
    }
}
