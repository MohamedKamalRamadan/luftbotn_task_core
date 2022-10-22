using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inv_Task.EF.Migrations
{
    public partial class Add_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });


            migrationBuilder.Sql("insert into Categories values('Category 1' , 0)");
            migrationBuilder.Sql("insert into Categories values('Category 2' , 0)");
            migrationBuilder.Sql("insert into Categories values('Category 3' , 0)");
            migrationBuilder.Sql("insert into Categories values('Category 4' , 0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
