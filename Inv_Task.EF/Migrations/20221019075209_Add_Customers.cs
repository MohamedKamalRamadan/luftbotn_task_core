using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;

#nullable disable

namespace Inv_Task.EF.Migrations
{
    public partial class Add_Customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });



            //fake Data
            migrationBuilder.Sql("Insert Into Customers values('Customer1','test1','01234567896',null,0)");
            migrationBuilder.Sql("Insert Into Customers values('Customer2','test2','01132152145',null,0)");
            migrationBuilder.Sql("Insert Into Customers values('Customer3','test3',null,'test3@test.com',0)");
            migrationBuilder.Sql("Insert Into Customers values('Customer4','test4',null,'test4@test.com',0)");


        }
     

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
