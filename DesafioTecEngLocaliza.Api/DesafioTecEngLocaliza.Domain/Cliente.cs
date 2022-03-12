using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecEngLocaliza.Domain
{
    public class Cliente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime? Dt_Aniversario { get; set; }
        public int? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
