using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Infrastructure.Migrations
{
    public partial class ChangeAttachmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FILE_CONTENT",
                table: "ATTACHMENT_FILE");

            migrationBuilder.AddColumn<string>(
                name: "FILE_CONTENT_DATA",
                table: "ATTACHMENT_FILE",
                type: "CLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FILE_CONTENT_DATA",
                table: "ATTACHMENT_FILE");

            migrationBuilder.AddColumn<byte[]>(
                name: "FILE_CONTENT",
                table: "ATTACHMENT_FILE",
                nullable: true);
        }
    }
}
