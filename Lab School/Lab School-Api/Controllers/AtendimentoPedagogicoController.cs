using AutoMapper;
using Lab_School_Api.Context;
using Lab_School_Api.Dto;
using Lab_School_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentoPedagogicoController : ControllerBase
    {

        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AtendimentoPedagogicoController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut()]
        public async Task<IActionResult> AtendimentoPedagogico(Atendimento atendimento)
        {
            Aluno aluno = await _context.Alunos.FindAsync(atendimento.codigoAluno);
            Pedagogo pedagogo = await _context.Pedagogos.FindAsync(atendimento.codigoPedagogo);
            if (aluno is null || pedagogo is null)
            {
                return NotFound("Aluno e/ou pedagogo não encontrado...");
            }   
                      
            aluno.Atendimentos = aluno.Atendimentos + 1;
            pedagogo.Atendimentos = pedagogo.Atendimentos + 1;
            _context.Entry(aluno).State = EntityState.Modified;
            _context.Entry(pedagogo).State = EntityState.Modified;
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            var pedagogoDto = _mapper.Map<PedagogoDto>(pedagogo);
            await _context.SaveChangesAsync();

            List<AtendimentoAluno> listaAluno = new List<AtendimentoAluno>();
            List<AtendimentoPedagogo> listaPedagogo = new List<AtendimentoPedagogo>();
            listaAluno.Add(new AtendimentoAluno { Codigo = alunoDto.Codigo, Nome = alunoDto.Nome, Telefone = alunoDto.Telefone, DataNascimento = alunoDto.DataNascimento, Cpf = alunoDto.Cpf, Situacao = alunoDto.Situacao, Nota = alunoDto.Nota, Atendimentos = alunoDto.Atendimentos });
            listaPedagogo.Add(new AtendimentoPedagogo { Codigo = pedagogoDto.Codigo, Nome = pedagogoDto.Nome, Telefone = pedagogoDto.Telefone, DataNascimento = pedagogoDto.DataNascimento, CPF = pedagogoDto.CPF, Atendimentos = pedagogoDto.Atendimentos });

            ArrayList lista = new ArrayList();
            lista.Add(listaAluno);
            lista.Add(listaPedagogo);


            return Ok(lista);


        }
    }
}
