using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace payment_system.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_ReceiverUserId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ReceiverUserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "Transaction",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                columns: new[] { "TransactionId", "UserId", "ReceiverId" });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReceiverId",
                table: "Transaction",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_ReceiverId",
                table: "Transaction",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_User_ReceiverId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ReceiverId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Transaction");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverUserId",
                table: "Transaction",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                columns: new[] { "TransactionId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReceiverUserId",
                table: "Transaction",
                column: "ReceiverUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_User_ReceiverUserId",
                table: "Transaction",
                column: "ReceiverUserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
