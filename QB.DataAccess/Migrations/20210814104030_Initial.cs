using Microsoft.EntityFrameworkCore.Migrations;

namespace QB.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Commented since database already exists and this is the initial code first migration ta should map 1 to 1 to the database schema.
            //Not going to run Update-Database either, since that's unnecessary at that point. It will just create the EFMigrations table which we do not need yet.

            //migrationBuilder.CreateTable(
            //    name: "Country",
            //    columns: table => new
            //    {
            //        CountryId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        CountryName = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Country", x => x.CountryId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "State",
            //    columns: table => new
            //    {
            //        StateId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        StateName = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
            //        CountryId = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_State", x => x.StateId);
            //        table.ForeignKey(
            //            name: "FK_State_Country_CountryId",
            //            column: x => x.CountryId,
            //            principalTable: "Country",
            //            principalColumn: "CountryId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "City",
            //    columns: table => new
            //    {
            //        CityId = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        CityName = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
            //        Population = table.Column<int>(type: "INTEGER", nullable: false),
            //        StateId = table.Column<int>(type: "INTEGER", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_City", x => x.CityId);
            //        table.ForeignKey(
            //            name: "FK_City_State_StateId",
            //            column: x => x.StateId,
            //            principalTable: "State",
            //            principalColumn: "StateId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //These two do not exist in the current database, but we consider them to be by design for the current project.
            //migrationBuilder.CreateIndex(
            //    name: "IX_City_StateId",
            //    table: "City",
            //    column: "StateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_State_CountryId",
            //    table: "State",
            //    column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "City");

            //migrationBuilder.DropTable(
            //    name: "State");

            //migrationBuilder.DropTable(
            //    name: "Country");
        }
    }
}
