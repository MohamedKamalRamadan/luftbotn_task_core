using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inv_Task.EF.Migrations
{
    public partial class Add_Sores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
                });

            migrationBuilder.Sql("insert into Stores values ('Store 1' ,0)");
            migrationBuilder.Sql("insert into Stores values ('Store 2' ,0)");
            migrationBuilder.Sql("insert into Stores values ('Store 3' ,0)");
            migrationBuilder.Sql("insert into Stores values ('Store 4' ,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
