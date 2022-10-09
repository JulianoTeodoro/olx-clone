using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class PopulandoEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO states(StatesId, Nome) VALUES(0, 'MG')");
            migrationBuilder.Sql("INSERT INTO states(StatesId, Nome) VALUES(1, 'RJ')");
            migrationBuilder.Sql("INSERT INTO states(StatesId, Nome) VALUES(2, 'SP')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM states");

        }
    }
}
