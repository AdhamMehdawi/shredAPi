using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Infrastructure.Migrations
{
    public partial class ChangeTablesFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UPDATED_BY",
                table: "USERS_TBL",
                newName: "LAST_MODIFIED_BY");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "USERS_TBL",
                newName: "LAST_MODIFIED_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "USERS_TBL",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "UPDATED_BY",
                table: "LOOKUPS",
                newName: "LAST_MODIFIED_BY");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "LOOKUPS",
                newName: "LAST_MODIFIED_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATED_DATE",
                table: "LOOKUPS",
                newName: "CREATED_AT");

            migrationBuilder.RenameColumn(
                name: "UPDATED_BY",
                table: "EMP_MASTER",
                newName: "LAST_MODIFIED_BY");

            migrationBuilder.RenameColumn(
                name: "UPDATE_DATE",
                table: "EMP_MASTER",
                newName: "LAST_MODIFIED_TIME");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "EMP_MASTER",
                newName: "CREATED_AT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RESET_TOKEN_EX_DATE",
                table: "USERS_TBL",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "IS_DELETED",
                table: "USERS_TBL",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DELETED",
                table: "LOOKUPS",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "LOOKUP_TYPES",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY",
                table: "LOOKUP_TYPES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DELETED",
                table: "LOOKUP_TYPES",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LAST_MODIFIED_BY",
                table: "LOOKUP_TYPES",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LAST_MODIFIED_TIME",
                table: "LOOKUP_TYPES",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "ATTACHMENT_FILE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CREATED_BY",
                table: "ATTACHMENT_FILE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IS_DELETED",
                table: "ATTACHMENT_FILE",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LAST_MODIFIED_BY",
                table: "ATTACHMENT_FILE",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LAST_MODIFIED_TIME",
                table: "ATTACHMENT_FILE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "USERS_TBL");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "LOOKUPS");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "LOOKUP_TYPES");

            migrationBuilder.DropColumn(
                name: "CREATED_BY",
                table: "LOOKUP_TYPES");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "LOOKUP_TYPES");

            migrationBuilder.DropColumn(
                name: "LAST_MODIFIED_BY",
                table: "LOOKUP_TYPES");

            migrationBuilder.DropColumn(
                name: "LAST_MODIFIED_TIME",
                table: "LOOKUP_TYPES");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "ATTACHMENT_FILE");

            migrationBuilder.DropColumn(
                name: "CREATED_BY",
                table: "ATTACHMENT_FILE");

            migrationBuilder.DropColumn(
                name: "IS_DELETED",
                table: "ATTACHMENT_FILE");

            migrationBuilder.DropColumn(
                name: "LAST_MODIFIED_BY",
                table: "ATTACHMENT_FILE");

            migrationBuilder.DropColumn(
                name: "LAST_MODIFIED_TIME",
                table: "ATTACHMENT_FILE");

            migrationBuilder.RenameColumn(
                name: "LAST_MODIFIED_TIME",
                table: "USERS_TBL",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "LAST_MODIFIED_BY",
                table: "USERS_TBL",
                newName: "UPDATED_BY");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "USERS_TBL",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "LAST_MODIFIED_TIME",
                table: "LOOKUPS",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "LAST_MODIFIED_BY",
                table: "LOOKUPS",
                newName: "UPDATED_BY");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "LOOKUPS",
                newName: "CREATED_DATE");

            migrationBuilder.RenameColumn(
                name: "LAST_MODIFIED_TIME",
                table: "EMP_MASTER",
                newName: "UPDATE_DATE");

            migrationBuilder.RenameColumn(
                name: "LAST_MODIFIED_BY",
                table: "EMP_MASTER",
                newName: "UPDATED_BY");

            migrationBuilder.RenameColumn(
                name: "CREATED_AT",
                table: "EMP_MASTER",
                newName: "CREATE_DATE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RESET_TOKEN_EX_DATE",
                table: "USERS_TBL",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
