using AutoMapper;
using Lab_School_Api.Context;
using Lab_School_Api.Dto;
using Lab_School_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaPorMatriculaController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public ConsultaPorMatriculaController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> ConsultaPorMatricula(string? consultaSituacao)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.ToListAsync();

            var alunosDTO = _mapper.Map<IEnumerable<AlunoDto>>(aluno);

            if (consultaSituacao == "IRREGULAR" || consultaSituacao == "ATIVO" || consultaSituacao == "ATENDIMENTO_PEDAGOGICO" || consultaSituacao == "INATIVO")
            {
                return Ok(alunosDTO.Where(s => s.Situacao == consultaSituacao));
            }



            return Ok(alunosDTO);

        }
    }
}
