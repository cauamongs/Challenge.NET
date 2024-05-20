using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    public class PreferenciaViagemModel
    {
        [Key]
        public int Id { get; set; }
        public string TipoCulinaria { get; set; }
        public string RestricoesAlimentares { get; set; }
        public string TipoTransporte { get; set; }
        public string TipoHospedagem { get; set; }
        public string ViajaSozinho { get; set; }

        [ForeignKey("Usuario")]
        public long UsuarioId { get; set; } 
        public UsuarioModel Usuario { get; set; } 
    }
}