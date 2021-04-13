using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeManagement.DataAccess.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserToId",
                table: "AppUserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_AppUserMessages_UserToId",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskTypeId",
                table: "Tasks",
                newName: "TaskType");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "UserTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDueDate",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "TaskIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MessageId",
                table: "Reactions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "PersonalIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FamilyId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserFromId",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_MessageId",
                table: "Reactions",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMessages_UserId",
                table: "AppUserMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserId",
                table: "AppUserMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Family_FamilyId",
                table: "AspNetUsers",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Messages_MessageId",
                table: "Reactions",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserId",
                table: "AppUserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Family_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Messages_MessageId",
                table: "Reactions");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_MessageId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUserMessages_UserId",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "TaskDueDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "TaskIssues");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "PersonalIssues");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserFromId",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppUserMessages");

            migrationBuilder.RenameColumn(
                name: "TaskType",
                table: "Tasks",
                newName: "TaskTypeId");

            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TaskName = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserMessages_UserToId",
                table: "AppUserMessages",
                column: "UserToId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserToId",
                table: "AppUserMessages",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
