using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inv_Task.EF.Migrations
{
    public partial class Add_Invoice_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inv_Details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inv_Master_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inv_Details_Inv_Master_Inv_Master_Id",
                        column: x => x.Inv_Master_Id,
                        principalTable: "Inv_Master",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inv_Details_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Details_Inv_Master_Id",
                table: "Inv_Details",
                column: "Inv_Master_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Details_Item_Id",
                table: "Inv_Details",
                column: "Item_Id");

            // fake data
            //master 1
            migrationBuilder.Sql("insert into Inv_Details values (1,1,20,30,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (1,2,100,50,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (1,3,300,30,GETDATE(),0)");

            //master 2
            migrationBuilder.Sql("insert into Inv_Details values (2,3,20,30,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (2,4,105,50,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (2,1,300,30,GETDATE(),0)");

            //master 3
            migrationBuilder.Sql("insert into Inv_Details values (3,1,20,30,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (3,3,10,50,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (3,4,500,30,GETDATE(),0)");

            //master 4
            migrationBuilder.Sql("insert into Inv_Details values (4,4,20,30,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (4,1,10,50,GETDATE(),0)");
            migrationBuilder.Sql("insert into Inv_Details values (4,2,30,30,GETDATE(),0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inv_Details");
        }
    }
}
