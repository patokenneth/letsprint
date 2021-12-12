using Microsoft.EntityFrameworkCore.Migrations;

namespace letsprint.Migrations
{
    public partial class updatekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_orders_OrderID1",
                table: "orderdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails");

            migrationBuilder.DropIndex(
                name: "IX_orderdetails_OrderID1",
                table: "orderdetails");

            migrationBuilder.DropColumn(
                name: "OrderID1",
                table: "orderdetails");

            migrationBuilder.AlterColumn<string>(
                name: "ItemID",
                table: "orderdetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "orderdetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_OrderID",
                table: "orderdetails",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_orders_OrderID",
                table: "orderdetails",
                column: "OrderID",
                principalTable: "orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderdetails_orders_OrderID",
                table: "orderdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails");

            migrationBuilder.DropIndex(
                name: "IX_orderdetails_OrderID",
                table: "orderdetails");

            migrationBuilder.AlterColumn<string>(
                name: "OrderID",
                table: "orderdetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemID",
                table: "orderdetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "OrderID1",
                table: "orderdetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderdetails",
                table: "orderdetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_orderdetails_OrderID1",
                table: "orderdetails",
                column: "OrderID1");

            migrationBuilder.AddForeignKey(
                name: "FK_orderdetails_orders_OrderID1",
                table: "orderdetails",
                column: "OrderID1",
                principalTable: "orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
