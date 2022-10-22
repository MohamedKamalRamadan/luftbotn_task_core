using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inv_Task.EF.Migrations
{
    public partial class Add_Invoice_Master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inv_Master",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inv_Master", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inv_Master_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inv_Master_Customer_Id",
                table: "Inv_Master",
                column: "Customer_Id");

            //Face Data
            migrationBuilder.Sql("Insert into Inv_Master values (1,DATEADD(month, 1, GETDATE()),GETDATE(),0,1)");
            migrationBuilder.Sql("Insert into Inv_Master values (2,DATEADD(day, 1, GETDATE()),GETDATE(),0,2)");
            migrationBuilder.Sql("Insert into Inv_Master values (3,DATEADD(year, 1, GETDATE()),GETDATE(),0,3)");
            migrationBuilder.Sql("Insert into Inv_Master values (4,DATEADD(day, 1, GETDATE()),GETDATE(),0,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inv_Master");
        }
    }
}
