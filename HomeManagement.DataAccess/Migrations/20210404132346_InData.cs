using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeManagement.DataAccess.Migrations
{
    public partial class InData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UsersId",
                table: "AppUserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AppUserMessages_ChatsId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalIssues_Reactions_ReactionsId",
                table: "PersonalIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AppUserMessages_ChatsId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Tasks_TasksId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskIssues_Reactions_ReactionsId",
                table: "TaskIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskIssues_Tasks_IssueWithTasksId",
                table: "TaskIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Tasks_TaskId",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskIssues",
                table: "TaskIssues");

            migrationBuilder.DropIndex(
                name: "IX_TaskIssues_IssueWithTasksId",
                table: "TaskIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalIssues",
                table: "PersonalIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatsId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserMessages",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "From",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "To",
                table: "AppUserMessages");

            migrationBuilder.RenameColumn(
                name: "TaskTypeId",
                table: "TaskTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "Tasks",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "IssueWithTasksId",
                table: "TaskIssues",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "TaskIssueId",
                table: "TaskIssues",
                newName: "IssueWithId");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "Reactions",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "ChatsId",
                table: "Reactions",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_TasksId",
                table: "Reactions",
                newName: "IX_Reactions_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ChatsId",
                table: "Reactions",
                newName: "IX_Reactions_ChatId");

            migrationBuilder.RenameColumn(
                name: "PersonalIssueId",
                table: "PersonalIssues",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ChatsId",
                table: "Messages",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "MessagesId",
                table: "Messages",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "AppUserMessages",
                newName: "UserToId");

            migrationBuilder.RenameColumn(
                name: "ChatsId",
                table: "AppUserMessages",
                newName: "UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserMessages_UsersId",
                table: "AppUserMessages",
                newName: "IX_AppUserMessages_UserToId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UserTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "TaskTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "TaskIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TaskIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ReactionsId",
                table: "Reactions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Reactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reactions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PersonalIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PersonalIssues",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Messages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChatId",
                table: "Messages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskIssues",
                table: "TaskIssues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalIssues",
                table: "PersonalIssues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserMessages",
                table: "AppUserMessages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskIssues_IssueWithId",
                table: "TaskIssues",
                column: "IssueWithId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserToId",
                table: "AppUserMessages",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AppUserMessages_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "AppUserMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalIssues_Reactions_ReactionsId",
                table: "PersonalIssues",
                column: "ReactionsId",
                principalTable: "Reactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AppUserMessages_ChatId",
                table: "Reactions",
                column: "ChatId",
                principalTable: "AppUserMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Tasks_TaskId",
                table: "Reactions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskIssues_Reactions_ReactionsId",
                table: "TaskIssues",
                column: "ReactionsId",
                principalTable: "Reactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskIssues_Tasks_IssueWithId",
                table: "TaskIssues",
                column: "IssueWithId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Tasks_TaskId",
                table: "UserTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UserToId",
                table: "AppUserMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AppUserMessages_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalIssues_Reactions_ReactionsId",
                table: "PersonalIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AppUserMessages_ChatId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Tasks_TaskId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskIssues_Reactions_ReactionsId",
                table: "TaskIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskIssues_Tasks_IssueWithId",
                table: "TaskIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Tasks_TaskId",
                table: "UserTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskIssues",
                table: "TaskIssues");

            migrationBuilder.DropIndex(
                name: "IX_TaskIssues_IssueWithId",
                table: "TaskIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalIssues",
                table: "PersonalIssues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserMessages",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaskTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TaskTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaskIssues");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TaskIssues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonalIssues");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PersonalIssues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AppUserMessages");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AppUserMessages");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TaskTypes",
                newName: "TaskTypeId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Tasks",
                newName: "TasksId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "TaskIssues",
                newName: "IssueWithTasksId");

            migrationBuilder.RenameColumn(
                name: "IssueWithId",
                table: "TaskIssues",
                newName: "TaskIssueId");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Reactions",
                newName: "TasksId");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Reactions",
                newName: "ChatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_TaskId",
                table: "Reactions",
                newName: "IX_Reactions_TasksId");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ChatId",
                table: "Reactions",
                newName: "IX_Reactions_ChatsId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PersonalIssues",
                newName: "PersonalIssueId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Messages",
                newName: "ChatsId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Messages",
                newName: "MessagesId");

            migrationBuilder.RenameColumn(
                name: "UserToId",
                table: "AppUserMessages",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "AppUserMessages",
                newName: "ChatsId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserMessages_UserToId",
                table: "AppUserMessages",
                newName: "IX_AppUserMessages_UsersId");

            migrationBuilder.AlterColumn<string>(
                name: "ReactionsId",
                table: "Reactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "AppUserMessages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskTypes",
                table: "TaskTypes",
                column: "TaskTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TasksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskIssues",
                table: "TaskIssues",
                column: "TaskIssueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reactions",
                table: "Reactions",
                column: "ReactionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalIssues",
                table: "PersonalIssues",
                column: "PersonalIssueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessagesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserMessages",
                table: "AppUserMessages",
                column: "ChatsId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskIssues_IssueWithTasksId",
                table: "TaskIssues",
                column: "IssueWithTasksId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatsId",
                table: "Messages",
                column: "ChatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserMessages_AspNetUsers_UsersId",
                table: "AppUserMessages",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AppUserMessages_ChatsId",
                table: "Messages",
                column: "ChatsId",
                principalTable: "AppUserMessages",
                principalColumn: "ChatsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalIssues_Reactions_ReactionsId",
                table: "PersonalIssues",
                column: "ReactionsId",
                principalTable: "Reactions",
                principalColumn: "ReactionsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AppUserMessages_ChatsId",
                table: "Reactions",
                column: "ChatsId",
                principalTable: "AppUserMessages",
                principalColumn: "ChatsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Tasks_TasksId",
                table: "Reactions",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "TasksId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskIssues_Reactions_ReactionsId",
                table: "TaskIssues",
                column: "ReactionsId",
                principalTable: "Reactions",
                principalColumn: "ReactionsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskIssues_Tasks_IssueWithTasksId",
                table: "TaskIssues",
                column: "IssueWithTasksId",
                principalTable: "Tasks",
                principalColumn: "TasksId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "TaskTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Tasks_TaskId",
                table: "UserTasks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TasksId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
