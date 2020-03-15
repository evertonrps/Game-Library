using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLibrary.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime", nullable: false),
                    WebSite = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPlataformas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPlataformas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "varchar(150)", nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    SenhaHash = table.Column<string>(maxLength: 255, nullable: false),
                    DataUltimoAcesso = table.Column<DateTime>(nullable: true),
                    Bloqueado = table.Column<bool>(nullable: false),
                    Tentativas = table.Column<int>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", maxLength: 150, nullable: true),
                    DeveloperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Desenvolvedoras_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Desenvolvedoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(150)", nullable: false),
                    PlatformTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plataformas_TiposPlataformas_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "TiposPlataformas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogosPlataformas",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogosPlataformas", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_JogosPlataformas_Jogos_GameId",
                        column: x => x.GameId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogosPlataformas_Plataformas_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Plataformas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_DeveloperId",
                table: "Jogos",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_JogosPlataformas_PlatformId",
                table: "JogosPlataformas",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_PlatformTypeId",
                table: "Plataformas",
                column: "PlatformTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogosPlataformas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Plataformas");

            migrationBuilder.DropTable(
                name: "Desenvolvedoras");

            migrationBuilder.DropTable(
                name: "TiposPlataformas");
        }
    }
}
