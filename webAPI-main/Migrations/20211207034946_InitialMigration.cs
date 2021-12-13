using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace webAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    BibliotecaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Libro = table.Column<string>(type: "text", nullable: true),
                    CategoriaLibro = table.Column<string>(type: "text", nullable: true),
                    NombreAutor = table.Column<string>(type: "text", nullable: true),
                    FechaDeLanzamiento = table.Column<string>(type: "text", nullable: true),
                    ISBN = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.BibliotecaID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    direccion = table.Column<string>(type: "text", nullable: true),
                    salario = table.Column<decimal>(type: "numeric", nullable: false),
                    BibliotecaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleados_Bibliotecas_BibliotecaID",
                        column: x => x.BibliotecaID,
                        principalTable: "Bibliotecas",
                        principalColumn: "BibliotecaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_BibliotecaID",
                table: "Empleados",
                column: "BibliotecaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Bibliotecas");
        }
    }
}
