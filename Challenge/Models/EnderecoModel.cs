using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        [ForeignKey("Usuario")]
        public long UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
