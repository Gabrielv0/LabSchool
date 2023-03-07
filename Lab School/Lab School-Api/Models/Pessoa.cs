using System.ComponentModel.DataAnnotations;

namespace Lab_School_Api.Models
{
    public class Pessoa
    {
        [Key]
        public int Codigo { get; set; } 

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public long CPF { get; set; }

    }
}
