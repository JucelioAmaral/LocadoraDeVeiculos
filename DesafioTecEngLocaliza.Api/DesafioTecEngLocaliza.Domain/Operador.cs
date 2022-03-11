using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecEngLocaliza.Domain
{
    public class Operador
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Matricula { get; set; }
        public string Nome { get; set; }
    }
}
