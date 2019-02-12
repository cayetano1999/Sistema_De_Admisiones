using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class SOLICITUDES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Solicitud_Admisiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    Aula = table.Column<string>(nullable: false),
                    Centro_Procedencia = table.Column<string>(nullable: false),
                    Curso = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 30, nullable: false),
                    Edad = table.Column<int>(maxLength: 2, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Estado_Solicitud = table.Column<string>(nullable: true),
                    Fecha_Nacimiento = table.Column<string>(nullable: false),
                    Fecha_Solicitud = table.Column<DateTime>(nullable: false),
                    ID_Usuario = table.Column<int>(nullable: false),
                    Lugar_Nacimiento = table.Column<string>(maxLength: 40, nullable: false),
                    Nivel = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Nombre_Madre = table.Column<string>(nullable: false),
                    Nombre_Padre = table.Column<string>(nullable: false),
                    Periodo_Escolar = table.Column<string>(nullable: false),
                    Tanda = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 12, nullable: false),
                    Telefono_Padres = table.Column<string>(nullable: false),
                    URL_Acta_Nacimiento = table.Column<string>(nullable: false),
                    URL_Certificado_Medico = table.Column<string>(nullable: false),
                    URL_Foto = table.Column<string>(nullable: false),
                    URL_Record_Notas = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud_Admisiones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Solicitud_Admisiones");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
