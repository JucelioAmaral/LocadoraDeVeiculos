using DesafioTecEngLocaliza.Application.Dtos;
using DesafioTecEngLocaliza.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecEngLocaliza.Application.DTO
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Dt_Aniversario { get; set; }
        public EnderecoDto Endereco { get; set; }
    }
}
