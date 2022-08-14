using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestBook.DataAccess.Migrations
{
    public partial class EditMessageReplyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReplies_AspNetUsers_UserId",
                table: "MessageReplies");

            migrationBuilder.DropIndex(
                name: "IX_MessageReplies_UserId",
                table: "MessageReplies");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MessageReplies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageReplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MessageReplies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MessageId",
                table: "MessageReplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageReplies_UserId",
                table: "MessageReplies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReplies_AspNetUsers_UserId",
                table: "MessageReplies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
