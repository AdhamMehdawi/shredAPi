using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Shared.Infrastructure.Migrations
{
    public partial class CreateInitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOOKUP_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    PARENT_ID = table.Column<int>(nullable: true),
                    EDITABLE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOOKUP_TYPES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOOKUP_TYPES_LOOKUP_TYPES_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "LOOKUP_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOOKUPS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    TITLE = table.Column<string>(maxLength: 150, nullable: false),
                    CODE = table.Column<string>(nullable: true),
                    PARENT_ID = table.Column<int>(nullable: true),
                    LOOKUP_TYPE_ID = table.Column<int>(nullable: true),
                    VALUE = table.Column<string>(nullable: true),
                    IS_PRIMARY = table.Column<int>(nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    CREATED_BY = table.Column<int>(nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    UPDATED_BY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOOKUPS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LOOKUPS_LOOKUP_TYPES_LOOKUP_TYPE_ID",
                        column: x => x.LOOKUP_TYPE_ID,
                        principalTable: "LOOKUP_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMP_MASTER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    EMP_NO = table.Column<int>(nullable: false),
                    ID_NO = table.Column<string>(maxLength: 15, nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 150, nullable: false),
                    SECOND_NAME = table.Column<string>(maxLength: 150, nullable: false),
                    THIRD_NAME = table.Column<string>(maxLength: 150, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 150, nullable: false),
                    DEP_ID = table.Column<int>(nullable: true),
                    MOTHER_NAME = table.Column<string>(nullable: true),
                    ID_TYPEID = table.Column<int>(nullable: false),
                    GENDER_ID = table.Column<int>(nullable: false),
                    MARTIAL_STATUS_ID = table.Column<int>(nullable: false),
                    BIRTHDATE = table.Column<DateTime>(nullable: true),
                    SHOW_IN_REPORTS = table.Column<bool>(nullable: false),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<int>(nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<int>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    LookupsId = table.Column<int>(nullable: true),
                    LookupsId1 = table.Column<int>(nullable: true),
                    LookupsId2 = table.Column<int>(nullable: true),
                    LookupsId3 = table.Column<int>(nullable: true),
                    LookupsId4 = table.Column<int>(nullable: true),
                    LookupsId5 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMP_MASTER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_GENDER_ID",
                        column: x => x.GENDER_ID,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_ID_TYPEID",
                        column: x => x.ID_TYPEID,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_LookupsId",
                        column: x => x.LookupsId,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_LookupsId1",
                        column: x => x.LookupsId1,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_LookupsId2",
                        column: x => x.LookupsId2,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_LookupsId3",
                        column: x => x.LookupsId3,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_LookupsId4",
                        column: x => x.LookupsId4,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_LookupsId5",
                        column: x => x.LookupsId5,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMP_MASTER_LOOKUPS_MARTIAL_STATUS_ID",
                        column: x => x.MARTIAL_STATUS_ID,
                        principalTable: "LOOKUPS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS_TBL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    USER_NAME = table.Column<string>(nullable: true),
                    PASSWORD = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    EMPLOYEE_ID = table.Column<int>(nullable: true),
                    FULL_NAME = table.Column<string>(nullable: true),
                    NEED_RESET_PASSWORD = table.Column<bool>(nullable: false),
                    PASS_EXPIRE_DATE = table.Column<DateTime>(nullable: true),
                    RESET_TOKEN = table.Column<string>(nullable: true),
                    RESET_TOKEN_EX_DATE = table.Column<DateTime>(nullable: false),
                    IS_SUPER_ADMIN = table.Column<bool>(nullable: false),
                    CREATE_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<int>(nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false),
                    UPDATED_BY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS_TBL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_TBL_EMP_MASTER_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMP_MASTER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_DEP_ID",
                table: "EMP_MASTER",
                column: "DEP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_EMP_NO",
                table: "EMP_MASTER",
                column: "EMP_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_GENDER_ID",
                table: "EMP_MASTER",
                column: "GENDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_ID_NO",
                table: "EMP_MASTER",
                column: "ID_NO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_ID_TYPEID",
                table: "EMP_MASTER",
                column: "ID_TYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_LookupsId",
                table: "EMP_MASTER",
                column: "LookupsId");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_LookupsId1",
                table: "EMP_MASTER",
                column: "LookupsId1");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_LookupsId2",
                table: "EMP_MASTER",
                column: "LookupsId2");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_LookupsId3",
                table: "EMP_MASTER",
                column: "LookupsId3");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_LookupsId4",
                table: "EMP_MASTER",
                column: "LookupsId4");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_LookupsId5",
                table: "EMP_MASTER",
                column: "LookupsId5");

            migrationBuilder.CreateIndex(
                name: "IX_EMP_MASTER_MARTIAL_STATUS_ID",
                table: "EMP_MASTER",
                column: "MARTIAL_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUP_TYPES_PARENT_ID",
                table: "LOOKUP_TYPES",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOOKUPS_LOOKUP_TYPE_ID",
                table: "LOOKUPS",
                column: "LOOKUP_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_TBL_EMPLOYEE_ID",
                table: "USERS_TBL",
                column: "EMPLOYEE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USERS_TBL");

            migrationBuilder.DropTable(
                name: "EMP_MASTER");

            migrationBuilder.DropTable(
                name: "LOOKUPS");

            migrationBuilder.DropTable(
                name: "LOOKUP_TYPES");
        }
    }
}
