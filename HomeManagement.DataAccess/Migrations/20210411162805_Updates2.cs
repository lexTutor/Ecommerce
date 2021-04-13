using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeManagement.DataAccess.Migrations
{
    public partial class Updates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserId",
                table: "AppUserMessages");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppUserMessages",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserMessages_UserId",
                table: "AppUserMessages",
                newName: "IX_AppUserMessages_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserToId",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserFromId",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMessages_UserFromId",
                table: "AppUserMessages",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMessages_UserToId",
                table: "AppUserMessages",
                column: "UserToId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_AppUserId",
                table: "AppUserMessages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserFromId",
                table: "AppUserMessages",
                column: "UserFromId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserToId",
                table: "AppUserMessages",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_AppUserId",
                table: "AppUserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserFromId",
                table: "AppUserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserToId",
                table: "AppUserMessages");

            migrationBuilder.DropIndex(
                name: "IX_AppUserMessages_UserFromId",
                table: "AppUserMessages");

            migrationBuilder.DropIndex(
                name: "IX_AppUserMessages_UserToId",
                table: "AppUserMessages");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "AppUserMessages",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserMessages_AppUserId",
                table: "AppUserMessages",
                newName: "IX_AppUserMessages_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserToId",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "UserFromId",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserId",
                table: "AppUserMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
