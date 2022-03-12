using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTecEngLocaliza.Application.Dtos
{
    public class EnderecoDto
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
