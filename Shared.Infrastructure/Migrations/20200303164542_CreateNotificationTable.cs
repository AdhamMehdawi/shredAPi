using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Shared.Infrastructure.Migrations
{
    public partial class CreateNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NOTIFICATION",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CREATED_AT = table.Column<DateTime>(nullable: false),
                    LAST_MODIFIED_TIME = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<int>(nullable: false),
                    LAST_MODIFIED_BY = table.Column<int>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    TITLE = table.Column<string>(nullable: false),
                    BODY = table.Column<string>(nullable: true),
                    FROM_USER = table.Column<int>(nullable: false),
                    TO_USER = table.Column<int>(nullable: false),
                    REDIRECT_URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATION", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTIFICATION");
        }
    }
}
