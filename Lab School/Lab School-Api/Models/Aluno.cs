namespace Lab_School_Api.Models
{
    public class Aluno : Pessoa
    {

        public string Situacao { get; set; }
        public double Nota { get; set; }

        public int Atendimentos { get; set; } = 0;
    }
}
