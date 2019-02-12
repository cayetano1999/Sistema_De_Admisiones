using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class USUARIOSREPERADOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_Usuario",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0   
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_Usuario",
                table: "AspNetUsers");
        }
    }
}
