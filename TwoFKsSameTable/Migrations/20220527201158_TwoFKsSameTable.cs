using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwoFKsSameTable.Migrations
{
    public partial class TwoFKsSameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PessoasDois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasDois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoasUm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Funcao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasUm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceitasDois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prescricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoFK = table.Column<int>(type: "int", nullable: false),
                    UtenteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitasDois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitasDois_PessoasDois_MedicoFK",
                        column: x => x.MedicoFK,
                        principalTable: "PessoasDois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceitasDois_PessoasDois_UtenteFK",
                        column: x => x.UtenteFK,
                        principalTable: "PessoasDois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceitasUm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prescricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicoFK = table.Column<int>(type: "int", nullable: false),
                    UtenteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitasUm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitasUm_PessoasUm_MedicoFK",
                        column: x => x.MedicoFK,
                        principalTable: "PessoasUm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);   // convertido de 'Cascade' para 'Restrict'
                   table.ForeignKey(
                        name: "FK_ReceitasUm_PessoasUm_UtenteFK",
                        column: x => x.UtenteFK,
                        principalTable: "PessoasUm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);   // convertido de 'Cascade' para 'Restrict'
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasDois_MedicoFK",
                table: "ReceitasDois",
                column: "MedicoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasDois_UtenteFK",
                table: "ReceitasDois",
                column: "UtenteFK");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasUm_MedicoFK",
                table: "ReceitasUm",
                column: "MedicoFK");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitasUm_UtenteFK",
                table: "ReceitasUm",
                column: "UtenteFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitasDois");

            migrationBuilder.DropTable(
                name: "ReceitasUm");

            migrationBuilder.DropTable(
                name: "PessoasDois");

            migrationBuilder.DropTable(
                name: "PessoasUm");
        }
    }
}
