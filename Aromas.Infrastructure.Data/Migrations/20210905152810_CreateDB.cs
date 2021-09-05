using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aromas.Infra.Data.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "aromas");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SubCategory = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", maxLength: 200, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POLICY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsInStock = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<int>(type: "integer", maxLength: 200, nullable: false),
                    Password = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Enable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyMenu",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PolicyId = table.Column<int>(type: "integer", nullable: false),
                    MenuId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POLICYMENU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POLICYMENU_MENU",
                        column: x => x.MenuId,
                        principalSchema: "aromas",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POLICYMENU_POLICY",
                        column: x => x.PolicyId,
                        principalSchema: "aromas",
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyUser",
                schema: "aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PolicyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POLICYUSER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POLICYUSER_POLICY",
                        column: x => x.PolicyId,
                        principalSchema: "aromas",
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POLICYUSER_USER",
                        column: x => x.UserId,
                        principalSchema: "aromas",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_NAME",
                schema: "aromas",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENU_NAME",
                schema: "aromas",
                table: "Menu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POLICY_NAME",
                schema: "aromas",
                table: "Policy",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POLICYMENU_IDAK",
                schema: "aromas",
                table: "PolicyMenu",
                columns: new[] { "PolicyId", "MenuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyMenu_MenuId",
                schema: "aromas",
                table: "PolicyMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_POLICYUSER_IDAK",
                schema: "aromas",
                table: "PolicyUser",
                columns: new[] { "PolicyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyUser_UserId",
                schema: "aromas",
                table: "PolicyUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_NAME",
                schema: "aromas",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USER_NAME",
                schema: "aromas",
                table: "User",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "aromas");

            migrationBuilder.DropTable(
                name: "PolicyMenu",
                schema: "aromas");

            migrationBuilder.DropTable(
                name: "PolicyUser",
                schema: "aromas");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "aromas");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "aromas");

            migrationBuilder.DropTable(
                name: "Policy",
                schema: "aromas");

            migrationBuilder.DropTable(
                name: "User",
                schema: "aromas");
        }
    }
}
