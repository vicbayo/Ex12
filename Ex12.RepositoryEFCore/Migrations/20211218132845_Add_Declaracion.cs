using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ex12.RepositoryEFCore.Migrations
{
    public partial class Add_Declaracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 18, 14, 28, 45, 136, DateTimeKind.Local).AddTicks(2007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 4, 10, 56, 28, 576, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.CreateTable(
                name: "Declaracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FechaDeclaracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ley = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaLey = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Articulo = table.Column<int>(type: "int", nullable: true),
                    BOE = table.Column<int>(type: "int", nullable: true),
                    FechaBOE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UrlBOE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declaracion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declaracion_Proyectos_Id",
                        column: x => x.Id,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Declaracion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 4, 10, 56, 28, 576, DateTimeKind.Local).AddTicks(7775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 18, 14, 28, 45, 136, DateTimeKind.Local).AddTicks(2007));
        }
    }
}
