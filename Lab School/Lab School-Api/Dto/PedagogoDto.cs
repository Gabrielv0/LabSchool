namespace Lab_School_Api.Dto
{
    public class PedagogoDto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public long CPF { get; set; }
        public int Atendimentos { get; set; } = 0;
    }

}
