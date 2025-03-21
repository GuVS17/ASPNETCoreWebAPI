using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInic = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataInic = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9199), new DateTime(2005, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2501, "Marta", "Kent", "11223344" },
                    { 2, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9235), new DateTime(2004, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2502, "Paula", "Isabela", "55667788" },
                    { 3, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9250), new DateTime(2004, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2503, "Laura", "Antonia", "99112233" },
                    { 4, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9263), new DateTime(2006, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2504, "Luiza", "Maria", "44556677" },
                    { 5, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9280), new DateTime(2005, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2505, "Lucas", "Machado", "88991122" },
                    { 6, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9297), new DateTime(2005, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2506, "Pedro", "Alvares", "33445566" },
                    { 7, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9311), new DateTime(2005, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2507, "Paulo", "José", "77889911" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInic", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8594), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8628), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8631), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8634), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(8638), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9416), null },
                    { 1, 4, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9427), null },
                    { 1, 5, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9431), null },
                    { 2, 1, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9434), null },
                    { 2, 2, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9437), null },
                    { 2, 5, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9443), null },
                    { 3, 1, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9446), null },
                    { 3, 2, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9448), null },
                    { 3, 3, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9451), null },
                    { 4, 1, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9456), null },
                    { 4, 4, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9459), null },
                    { 4, 5, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9462), null },
                    { 5, 4, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9464), null },
                    { 5, 5, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9467), null },
                    { 6, 1, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9469), null },
                    { 6, 2, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9472), null },
                    { 6, 3, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9475), null },
                    { 6, 4, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9479), null },
                    { 7, 1, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9482), null },
                    { 7, 2, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9485), null },
                    { 7, 3, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9488), null },
                    { 7, 4, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9491), null },
                    { 7, 5, null, new DateTime(2025, 3, 21, 9, 47, 59, 489, DateTimeKind.Local).AddTicks(9494), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaId",
                table: "AlunoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
