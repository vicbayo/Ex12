using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ex12.RepositoryEFCore.Migrations
{
    public partial class DeclaracionCambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlBOE",
                table: "Declaracion");

            migrationBuilder.RenameColumn(
                name: "BOE",
                table: "Declaracion",
                newName: "NumeroBOE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 11, 23, 4, 40, 215, DateTimeKind.Local).AddTicks(5816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 18, 14, 28, 45, 136, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.AddColumn<string>(
                name: "ReferenciaBOE",
                table: "Declaracion",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenciaBOE",
                table: "Declaracion");

            migrationBuilder.RenameColumn(
                name: "NumeroBOE",
                table: "Declaracion",
                newName: "BOE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 18, 14, 28, 45, 136, DateTimeKind.Local).AddTicks(2007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 11, 23, 4, 40, 215, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.AddColumn<string>(
                name: "UrlBOE",
                table: "Declaracion",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }
    }
}
