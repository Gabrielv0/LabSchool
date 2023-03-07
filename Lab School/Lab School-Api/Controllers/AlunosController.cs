using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab_School_Api.Context;
using Lab_School_Api.Models;
using AutoMapper;
using Lab_School_Api.Dto;

namespace Lab_School_Api.Controllers
{
    [Route("api/alunos")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AlunosController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
          if (_context.Alunos == null)
          {
              return NotFound();
          }

            var aluno = await _context.Alunos.ToListAsync();
            var alunosDTO = _mapper.Map<IEnumerable<AlunoDto>>(aluno);

            return Ok(alunosDTO);
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
          if (_context.Alunos == null)
          {
              return NotFound();
          }
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutAlunos(int codigo, Aluno aluno)
        {

            if (codigo != aluno.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(codigo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(CadastroAlunoDto cadastroAlunoDto)
        {
         
            Aluno aluno = _mapper.Map<Aluno>(cadastroAlunoDto);
            if(_context.Alunos.Where(c => c.CPF == aluno.CPF).Any())
            {
                return Conflict("O cpf já está cadastrado em outro aluno");
            }
            if (aluno.Situacao != "IRREGULAR" && aluno.Situacao != "ATIVO" && aluno.Situacao != "ATENDIMENTO_PEDAGOGICO" && aluno.Situacao != "INATIVO")
            {
                return BadRequest("O aluno só pode se cadastro no campo situação com as seguintes opcoes: " +
                    "ATIVO, IRREGULAR, ATENDIMENTO_PEDAGOGICO ou INATIVO");
            }
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            var alunoResp = _mapper.Map<AlunoDto>(aluno);   

            return Ok(alunoResp);
            
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteAluno(int codigo)
        {
            if (_context.Alunos == null)
            {
                return NotFound();
            }
            var aluno = await _context.Alunos.FindAsync(codigo);
            if (aluno == null)
            {
                return NotFound("O codigo informado não corresponde a nenhum aluno");
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunoExists(int id)
        {
            return (_context.Alunos?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
