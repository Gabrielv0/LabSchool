using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBancoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false),
                    Atendimentos = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Pedagogos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atendimentos = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagogos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormacaoAcademica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Codigo);
                });

            migrationBuilder.Sql("Insert into Alunos values('IRREGULAR',3.5,0,'Bart Simpson','11-11111-1212','2014-10-29', 11839750073)");
            migrationBuilder.Sql("Insert into Alunos values('ATIVO',10,0,'Lisa Simpson','11-22222-2222','2012-10-29', 17158947076)");
            migrationBuilder.Sql("Insert into Alunos values('ATIVO',9,0,'Meggie Simpson','12-20002-2200','2019-10-29', 63701210020)");
            migrationBuilder.Sql("Insert into Alunos values('ATIVO',8,0,'Milhouse Van Houten','11-33333-2222','2014-10-29', 30119137062)");
            migrationBuilder.Sql("Insert into Alunos values('INATIVO',2,0,'Nelson Muntz','11-44333-4444','2007-10-29', 95704094015)");



            migrationBuilder.Sql("Insert into Professores values('ATIVO','FULL_STACK','MESTRADO','Walter White','14-22998-1882','1982-10-30','40539019011')");
            migrationBuilder.Sql("Insert into Professores values('ATIVO','BACK_END','GRADUACAO_INCOMPLETA'	,'Jesse Pinkman','44-11111-1992','1997-10-30','96107295097')");
            migrationBuilder.Sql("Insert into Professores values('ATIVO','FULL_STACK','MESTRADO','Hank Schrader','44-11111-1002','1984-10-30','70685977005')");
            migrationBuilder.Sql("Insert into Professores values('INATIVO','FRONT_END','GRADUACAO_COMPLETA','Gustavo Fring','44-11001-1002','1977-10-30','57408927085')");
            migrationBuilder.Sql("Insert into Professores values('ATIVO','FULL_STACK','MESTRADO','Saul Goodman','44-11998-1882','1980-10-30','86940162062')");


            migrationBuilder.Sql("Insert into Pedagogos values(0,'John Snow','11-67333-4454','2000-10-30','62316840086')");
            migrationBuilder.Sql("Insert into Pedagogos values(0,'Sansa Stark','22-22333-4454','2004-10-30','49850253053')");
            migrationBuilder.Sql("Insert into Pedagogos values(0,'Tyrion Lannister','33-77333-4454','1990-10-30','39125106015')");
            migrationBuilder.Sql("Insert into Pedagogos values(0,'Sandor Clegane','11-33333-2222','1995-10-30','89089606009')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Pedagogos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
