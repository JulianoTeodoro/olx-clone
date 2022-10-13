using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

#nullable disable

namespace backend.Migrations
{
    public partial class PopulaEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT states ON");
            migrationBuilder.Sql("INSERT INTO states(StatesId, Nome) VALUES(0, 'MG')");
            migrationBuilder.Sql("INSERT INTO states(StatesId, Nome) VALUES(1, 'RJ')");
            migrationBuilder.Sql("INSERT INTO states(StatesId, Nome) VALUES(2, 'SP')");
            migrationBuilder.Sql("SET IDENTITY_INSERT states OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM states");

        }
    }
}
