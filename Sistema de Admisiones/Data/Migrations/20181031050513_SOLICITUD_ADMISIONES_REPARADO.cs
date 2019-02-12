using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sistema_de_Admisiones.Data.Migrations
{
    public partial class SOLICITUD_ADMISIONES_REPARADO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Solicitud_Admisiones",
                newName: "ID_Solicitud");

            migrationBuilder.AlterColumn<string>(
                name: "URL_Record_Notas",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL_Foto",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL_Certificado_Medico",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "URL_Acta_Nacimiento",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fecha_Solicitud",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Estado_Solicitud",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_Usuario",
                table: "Solicitud_Admisiones",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_Usuario",
                table: "Solicitud_Admisiones");

            migrationBuilder.RenameColumn(
                name: "ID_Solicitud",
                table: "Solicitud_Admisiones",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "URL_Record_Notas",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL_Foto",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL_Certificado_Medico",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "URL_Acta_Nacimiento",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Solicitud",
                table: "Solicitud_Admisiones",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Estado_Solicitud",
                table: "Solicitud_Admisiones",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
