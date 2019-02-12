using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class USUARIOSADMIN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosAdmin",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(nullable: false),
                    Clave = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Imagen = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Nombre_Usuario = table.Column<string>(nullable: false),
                    Referencia_Clave = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Tipo_Usuario = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosAdmin", x => x.ID_Usuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosAdmin");
        }
    }
}
