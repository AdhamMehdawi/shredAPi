using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Infrastructure.Migrations
{
    public partial class AddAttachmentFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttachmentFiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FILE_NAME = table.Column<string>(nullable: false),
                    FILE_EXTENSION = table.Column<string>(nullable: false),
                    FILE_SIZE = table.Column<long>(nullable: false),
                    FILE_CONTENT = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentFiles", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentFiles");
        }
    }
}
