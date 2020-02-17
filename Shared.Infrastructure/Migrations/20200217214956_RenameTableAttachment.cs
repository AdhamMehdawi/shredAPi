using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Infrastructure.Migrations
{
    public partial class RenameTableAttachment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AttachmentFiles",
                table: "AttachmentFiles");

            migrationBuilder.RenameTable(
                name: "AttachmentFiles",
                newName: "ATTACHMENT_FILE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ATTACHMENT_FILE",
                table: "ATTACHMENT_FILE",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ATTACHMENT_FILE",
                table: "ATTACHMENT_FILE");

            migrationBuilder.RenameTable(
                name: "ATTACHMENT_FILE",
                newName: "AttachmentFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttachmentFiles",
                table: "AttachmentFiles",
                column: "ID");
        }
    }
}
