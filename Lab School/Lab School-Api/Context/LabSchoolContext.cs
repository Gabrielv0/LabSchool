using Lab_School_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_School_Api.Context
{
    public class LabSchoolContext : DbContext
    {
        public LabSchoolContext(DbContextOptions<LabSchoolContext> options) : base(options) { }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Pedagogo> Pedagogos { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }



    }
}
