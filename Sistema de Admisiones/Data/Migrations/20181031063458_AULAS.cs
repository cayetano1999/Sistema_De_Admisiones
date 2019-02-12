using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class AULAS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    ID_AULA = table.Column<string>(nullable: false),
                    Cupo = table.Column<int>(nullable: false),
                    Curso = table.Column<string>(nullable: false),
                    ID_Curso = table.Column<string>(nullable: false),
                    Nivel = table.Column<string>(nullable: false),
                    Nombre_Aula = table.Column<string>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.ID_AULA);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aulas");
        }
    }
}
