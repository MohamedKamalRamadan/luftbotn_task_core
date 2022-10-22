using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inv_Task.EF.Migrations
{
    public partial class Add_Items : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Store_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Items_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Stores_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Stores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category_Id",
                table: "Items",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Store_Id",
                table: "Items",
                column: "Store_Id");

            migrationBuilder.Sql("insert into Items values('Item 1' , 6 , 20 , 0 , 1, 1)");
            migrationBuilder.Sql("insert into Items values('Item 2' , 16 , 10 , 0 , 2, 2)");
            migrationBuilder.Sql("insert into Items values('Item 3' , 25 , 5 , 0 , 3, 3)");
            migrationBuilder.Sql("insert into Items values('Item 4' , 18 , 100 , 0 , 4, 4)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
