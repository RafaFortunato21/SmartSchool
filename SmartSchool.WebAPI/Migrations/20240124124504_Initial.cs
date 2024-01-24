using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: true),
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
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
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
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    SobreNome = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: true),
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
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: true)
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
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PreRequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
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
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
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
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataEncerramento", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4828), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4835), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4838), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4841), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4844), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4847), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4850), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
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
                columns: new[] { "Id", "Ativo", "DataEncerramento", "DataInicio", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4669), "Lauro", 1, "Oliveira", null },
                    { 2, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4680), "Roberto", 2, "Soares", null },
                    { 3, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4681), "Ronaldo", 3, "Marconi", null },
                    { 4, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4682), "Rodrigo", 4, "Carvalho", null },
                    { 5, true, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4683), "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
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
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataEncerramento", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4870), null },
                    { 1, 4, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4872), null },
                    { 1, 5, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4873), null },
                    { 2, 1, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4874), null },
                    { 2, 2, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4874), null },
                    { 2, 5, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4876), null },
                    { 3, 1, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4876), null },
                    { 3, 2, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4877), null },
                    { 3, 3, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4878), null },
                    { 4, 1, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4879), null },
                    { 4, 4, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4880), null },
                    { 4, 5, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4880), null },
                    { 5, 4, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4881), null },
                    { 5, 5, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4882), null },
                    { 6, 1, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4882), null },
                    { 6, 2, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4883), null },
                    { 6, 3, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4884), null },
                    { 6, 4, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4885), null },
                    { 7, 1, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4886), null },
                    { 7, 2, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4886), null },
                    { 7, 3, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4887), null },
                    { 7, 4, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4888), null },
                    { 7, 5, null, new DateTime(2024, 1, 24, 9, 45, 3, 870, DateTimeKind.Local).AddTicks(4889), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
