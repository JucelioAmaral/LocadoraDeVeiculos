using DesafioTecEngLocaliza.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DesafioTecEngLocaliza.Domain
{
    public class Veiculo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Placa { get; set; }
        public int? MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int? ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public int Ano { get; set; }
        public double ValorHora { get; set; }
        public Combustivel Combustivel { get; set; }
        public double LimitePortaMalas { get; set; }
        public Categoria Categoria { get; set; }
    }
}
