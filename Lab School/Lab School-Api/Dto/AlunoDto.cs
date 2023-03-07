using AutoMapper.Configuration.Annotations;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Lab_School_Api.Dto
{
    public class CadastroAlunoDto    
    {
        
        [Required]
        [StringLength(100)]
        [MinLength(5, ErrorMessage = "O campo nome precisar ter no minimo 5 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(12, ErrorMessage = "O campo telefone precisar ter no minimo 12 caracteres")]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public long Cpf {  get; set; }
        [Required]        
        public string Situacao { get; set; }
        [Required]
        public double Nota { get; set; }
    }

    public class AlunoDto
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

    public class SituacaoMatriculaDto
    {
        public string Situacao { get; set; }
    }
}
