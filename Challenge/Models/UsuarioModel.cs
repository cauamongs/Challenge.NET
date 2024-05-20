using System.ComponentModel.DataAnnotations;



namespace Challenge.Models
{
    public class UsuarioModel
    {
        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }

    }

}