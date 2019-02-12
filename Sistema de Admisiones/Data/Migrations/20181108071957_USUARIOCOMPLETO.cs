using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class USUARIOCOMPLETO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_Usuario",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Usuario",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tipo_Usuario",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ID_Usuario",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
