﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.WebAPI.data;

#nullable disable

namespace SmartSchool.WebAPI.Migrations
{
    [DbContext(typeof(SmartContext))]
    partial class SmartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SmartSchool.WebAPI.models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInic")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9199),
                            DataNasc = new DateTime(2005, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2501,
                            Nome = "Marta",
                            Sobrenome = "Kent",
                            Telefone = "11223344"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9235),
                            DataNasc = new DateTime(2004, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2502,
                            Nome = "Paula",
                            Sobrenome = "Isabela",
                            Telefone = "55667788"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9250),
                            DataNasc = new DateTime(2004, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2503,
                            Nome = "Laura",
                            Sobrenome = "Antonia",
                            Telefone = "99112233"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9263),
                            DataNasc = new DateTime(2006, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2504,
                            Nome = "Luiza",
                            Sobrenome = "Maria",
                            Telefone = "44556677"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9280),
                            DataNasc = new DateTime(2005, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2505,
                            Nome = "Lucas",
                            Sobrenome = "Machado",
                            Telefone = "88991122"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9297),
                            DataNasc = new DateTime(2005, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2506,
                            Nome = "Pedro",
                            Sobrenome = "Alvares",
                            Telefone = "33445566"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9311),
                            DataNasc = new DateTime(2005, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2507,
                            Nome = "Paulo",
                            Sobrenome = "José",
                            Telefone = "77889911"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunoDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9416)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9427)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9431)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9434)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9437)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9443)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9446)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9448)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9451)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9456)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9459)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9462)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9464)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9467)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9469)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9472)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9475)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9479)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9482)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9485)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9488)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9491)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataIni = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9494)
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tecnologia da Informação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Sistemas de Informação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Ciência da Computação"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInic")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Registro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8594),
                            Nome = "Lauro",
                            Registro = 1,
                            Sobrenome = "Oliveira"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8628),
                            Nome = "Roberto",
                            Registro = 2,
                            Sobrenome = "Soares"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8631),
                            Nome = "Ronaldo",
                            Registro = 3,
                            Sobrenome = "Marconi"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8634),
                            Nome = "Rodrigo",
                            Registro = 4,
                            Sobrenome = "Carvalho"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInic = new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8638),
                            Nome = "Alexandre",
                            Registro = 5,
                            Sobrenome = "Montanha"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.AlunoCurso", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("SmartSchool.WebAPI.models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Prerequisito");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Aluno", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Disciplina", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.models.Professor", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
