using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class AULASREPARADA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_AULA",
                table: "Aulas",
                newName: "ID_Aula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_Aula",
                table: "Aulas",
                newName: "ID_AULA");
        }
    }
}
