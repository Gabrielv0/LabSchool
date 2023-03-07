using AutoMapper;
using Lab_School_Api.Dto;
using Lab_School_Api.Models;

namespace Lab_School_Api
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Aluno, AlunoDto>();
            CreateMap<AlunoDto, Aluno>();

            CreateMap<Aluno, CadastroAlunoDto>();
            CreateMap<CadastroAlunoDto, Aluno>();

            CreateMap<Aluno,SituacaoMatriculaDto>();
            CreateMap<SituacaoMatriculaDto, Aluno>();

            CreateMap<Professor, ProfessorDto>();
            CreateMap<ProfessorDto, Professor>();

            CreateMap<Pedagogo, PedagogoDto>();
            CreateMap<PedagogoDto, Pedagogo>();
            
        }
    }
}
