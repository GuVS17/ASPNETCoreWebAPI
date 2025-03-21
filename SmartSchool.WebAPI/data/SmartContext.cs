using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.models;
using SQLitePCL;

namespace SmartSchool.WebAPI.data
{
    public class SmartContext : DbContext // Onde vai criar as tabelas
    {

        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { } //conecta com o Startup
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)   // Quando tiver criando o banco de dados, estou dizendo que quero que esse método seja executado 
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});  // Está criando um muitos pra muitos

            builder.Entity<AlunoCurso>()
                .HasKey(AD => new {AD.AlunoId, AD.CursoId});

            builder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, 1, "Lauro", "Oliveira"),
                    new Professor(2, 2, "Roberto", "Soares"),
                    new Professor(3, 3, "Ronaldo", "Marconi"),
                    new Professor(4, 4, "Rodrigo", "Carvalho"),
                    new Professor(5, 5, "Alexandre", "Montanha"),
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>(){
                    new Curso(1, "Tecnologia da Informação"),
                    new Curso(2, "Sistemas de Informação"),
                    new Curso(3, "Ciência da Computação"),
                }); 

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Matemática", 1, 1),
                    new Disciplina(2, "Matemática", 1,3),
                    new Disciplina(3, "Física", 2, 3),
                    new Disciplina(4, "Português", 3, 1),
                    new Disciplina(5, "Inglês", 4,1),
                    new Disciplina(6, "Inglês", 4,2),
                    new Disciplina(7, "Inglês", 4,3),
                    new Disciplina(8, "Programação", 5, 1),
                    new Disciplina(9, "Programação", 5, 2),
                    new Disciplina(10, "Programação", 5, 3)
               });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, 2501, "Marta", "Kent", "11223344", DateTime.Parse("17/03/2005")),
                    new Aluno(2, 2502, "Paula", "Isabela", "55667788", DateTime.Parse("30/06/2004")),
                    new Aluno(3, 2503, "Laura", "Antonia", "99112233", DateTime.Parse("25/08/2004")),
                    new Aluno(4, 2504, "Luiza", "Maria", "44556677", DateTime.Parse("06/07/2006")),
                    new Aluno(5, 2505, "Lucas", "Machado", "88991122", DateTime.Parse("08/01/2005")),
                    new Aluno(6, 2506, "Pedro", "Alvares", "33445566", DateTime.Parse("04/09/2005")),
                    new Aluno(7, 2507, "Paulo", "José", "77889911", DateTime.Parse("13/10/2005")),
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>(){
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });
        }
    }
}