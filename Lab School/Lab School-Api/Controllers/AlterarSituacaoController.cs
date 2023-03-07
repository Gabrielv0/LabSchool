using AutoMapper;
using Lab_School_Api.Context;
using Lab_School_Api.Dto;
using Lab_School_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Packaging;
using NuGet.Protocol;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab_School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlterarSituacaoController : ControllerBase
    {

        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AlterarSituacaoController(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // PUT api/<AlterarSituacaoController>/5
        [HttpPut("{codigo}")]
        public async Task<IActionResult> AlterarSituacao(int codigo, SituacaoMatriculaDto situacaoMatriculaDto)
        {
            Aluno aluno = await _context.Alunos.FindAsync(codigo);
            if (aluno is null)
            {
                return NotFound("Aluno não encontrado no banco de dados...");
            }
            if (situacaoMatriculaDto.Situacao != "IRREGULAR" && situacaoMatriculaDto.Situacao != "ATIVO" && situacaoMatriculaDto.Situacao != "ATENDIMENTO_PEDAGOGICO" && situacaoMatriculaDto.Situacao != "INATIVO")
            {
                return BadRequest("O campo situação só pode ser alterado com as seguintes opcoes: " +
                    "ATIVO, IRREGULAR, ATENDIMENTO_PEDAGOGICO ou INATIVO");
            }
            aluno.Situacao = situacaoMatriculaDto.Situacao;
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }             

    }
}
