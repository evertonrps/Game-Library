using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameLibrary.Data.Migrations
{
    public partial class ChangeProducerToDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Producers_ProducerId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.RenameColumn(
                name: "ProducerId",
                table: "Games",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ProducerId",
                table: "Games",
                newName: "IX_Games_DeveloperId");

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime", nullable: false),
                    WebSite = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Games",
                newName: "ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                newName: "IX_Games_ProducerId");

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Founded = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    WebSite = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Producers_ProducerId",
                table: "Games",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
