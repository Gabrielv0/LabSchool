namespace Lab_School_Api.Models
{
    public class Atendimento
    {
        public int codigoAluno { get; set; }
        public int codigoPedagogo { get; set; }
    }

        public class AtendimentoAluno
        {

            public int Codigo { get; set; }
            public string Nome { get; set; }
            public string Telefone { get; set; }
            public DateTime DataNascimento { get; set; }
            public long Cpf { get; set; }
            public string Situacao { get; set; }
            public double Nota { get; set; }
            public int Atendimentos { get; set; }

        }

        public class listaAluno : AtendimentoAluno
        {
            public List<AtendimentoAluno> AtendimentoAluno { get; set; }
        }

        public class AtendimentoPedagogo
    {
            public int Codigo { get; set; }

            public string Nome { get; set; }
            public string Telefone { get; set; }
            public DateTime DataNascimento { get; set; }
            public long CPF { get; set; }
            public int Atendimentos { get; set; } = 0;


        }


        public class listaPedagogo : AtendimentoPedagogo
    {
            public List<AtendimentoPedagogo> AtendimentoPedagogo { get; set; }
        }
    }


