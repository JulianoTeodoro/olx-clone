using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class PopulandoEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO states(Nome) VALUES('MG')");
            migrationBuilder.Sql("INSERT INTO states(Nome) VALUES('RJ')");
            migrationBuilder.Sql("INSERT INTO states(Nome) VALUES('SP')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM states");

        }
    }
}
