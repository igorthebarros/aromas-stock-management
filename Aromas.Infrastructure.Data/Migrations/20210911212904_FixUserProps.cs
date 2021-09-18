using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aromas.Infra.Data.Migrations
{
    public partial class FixUserProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesMenu_Menus_MenuId",
                table: "PoliciesMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesMenu_Policies_PolicyId",
                table: "PoliciesMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesUser_Policies_PolicyId",
                table: "PoliciesUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesUser_Users_UserId",
                table: "PoliciesUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliciesUser",
                table: "PoliciesUser");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesUser_PolicyId",
                table: "PoliciesUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliciesMenu",
                table: "PoliciesMenu");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesMenu_PolicyId",
                table: "PoliciesMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Policies",
                table: "Policies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "PoliciesUser");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PoliciesMenu");

            migrationBuilder.DropColumn(
                name: "PermissioId",
                table: "PoliciesMenu");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PoliciesMenu");

            migrationBuilder.EnsureSchema(
                name: "aromas");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "aromas");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product",
                newSchema: "aromas");

            migrationBuilder.RenameTable(
                name: "PoliciesUser",
                newName: "PolicyUser",
                newSchema: "aromas");

            migrationBuilder.RenameTable(
                name: "PoliciesMenu",
                newName: "PolicyMenu",
                newSchema: "aromas");

            migrationBuilder.RenameTable(
                name: "Policies",
                newName: "Policy",
                newSchema: "aromas");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu",
                newSchema: "aromas");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category",
                newSchema: "aromas");

            migrationBuilder.RenameColumn(
                name: "Active",
                schema: "aromas",
                table: "User",
                newName: "Enable");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "aromas",
                table: "Product",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_PoliciesUser_UserId",
                schema: "aromas",
                table: "PolicyUser",
                newName: "IX_PolicyUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliciesMenu_MenuId",
                schema: "aromas",
                table: "PolicyMenu",
                newName: "IX_PolicyMenu_MenuId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "aromas",
                table: "User",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                schema: "aromas",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "aromas",
                table: "User",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aromas",
                table: "User",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "aromas",
                table: "User",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "aromas",
                table: "User",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "aromas",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aromas",
                table: "Product",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsInStock",
                schema: "aromas",
                table: "Product",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "aromas",
                table: "Product",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Category",
                schema: "aromas",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                schema: "aromas",
                table: "PolicyUser",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                schema: "aromas",
                table: "PolicyMenu",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "aromas",
                table: "Policy",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "aromas",
                table: "Policy",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "aromas",
                table: "Policy",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "aromas",
                table: "Menu",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "aromas",
                table: "Menu",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aromas",
                table: "Menu",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "aromas",
                table: "Menu",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "aromas",
                table: "Menu",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "SubCategory",
                schema: "aromas",
                table: "Category",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "aromas",
                table: "Category",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "aromas",
                table: "Category",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                schema: "aromas",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCT",
                schema: "aromas",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POLICYUSER",
                schema: "aromas",
                table: "PolicyUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POLICYMENU",
                schema: "aromas",
                table: "PolicyMenu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_POLICY",
                schema: "aromas",
                table: "Policy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MENU",
                schema: "aromas",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORY",
                schema: "aromas",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_NAME",
                schema: "aromas",
                table: "User",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_NAME",
                schema: "aromas",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POLICYUSER_IDAK",
                schema: "aromas",
                table: "PolicyUser",
                columns: new[] { "PolicyId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POLICYMENU_IDAK",
                schema: "aromas",
                table: "PolicyMenu",
                columns: new[] { "PolicyId", "MenuId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POLICY_NAME",
                schema: "aromas",
                table: "Policy",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENU_NAME",
                schema: "aromas",
                table: "Menu",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_NAME",
                schema: "aromas",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_POLICYMENU_MENU",
                schema: "aromas",
                table: "PolicyMenu",
                column: "MenuId",
                principalSchema: "aromas",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POLICYMENU_POLICY",
                schema: "aromas",
                table: "PolicyMenu",
                column: "PolicyId",
                principalSchema: "aromas",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POLICYUSER_POLICY",
                schema: "aromas",
                table: "PolicyUser",
                column: "PolicyId",
                principalSchema: "aromas",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_POLICYUSER_USER",
                schema: "aromas",
                table: "PolicyUser",
                column: "UserId",
                principalSchema: "aromas",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_POLICYMENU_MENU",
                schema: "aromas",
                table: "PolicyMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_POLICYMENU_POLICY",
                schema: "aromas",
                table: "PolicyMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_POLICYUSER_POLICY",
                schema: "aromas",
                table: "PolicyUser");

            migrationBuilder.DropForeignKey(
                name: "FK_POLICYUSER_USER",
                schema: "aromas",
                table: "PolicyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                schema: "aromas",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_USER_NAME",
                schema: "aromas",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCT",
                schema: "aromas",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCT_NAME",
                schema: "aromas",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POLICYUSER",
                schema: "aromas",
                table: "PolicyUser");

            migrationBuilder.DropIndex(
                name: "IX_POLICYUSER_IDAK",
                schema: "aromas",
                table: "PolicyUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POLICYMENU",
                schema: "aromas",
                table: "PolicyMenu");

            migrationBuilder.DropIndex(
                name: "IX_POLICYMENU_IDAK",
                schema: "aromas",
                table: "PolicyMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_POLICY",
                schema: "aromas",
                table: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_POLICY_NAME",
                schema: "aromas",
                table: "Policy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MENU",
                schema: "aromas",
                table: "Menu");

            migrationBuilder.DropIndex(
                name: "IX_MENU_NAME",
                schema: "aromas",
                table: "Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORY",
                schema: "aromas",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_CATEGORY_NAME",
                schema: "aromas",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "aromas",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "aromas",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "PolicyUser",
                schema: "aromas",
                newName: "PoliciesUser");

            migrationBuilder.RenameTable(
                name: "PolicyMenu",
                schema: "aromas",
                newName: "PoliciesMenu");

            migrationBuilder.RenameTable(
                name: "Policy",
                schema: "aromas",
                newName: "Policies");

            migrationBuilder.RenameTable(
                name: "Menu",
                schema: "aromas",
                newName: "Menus");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "aromas",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "Enable",
                table: "Users",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyUser_UserId",
                table: "PoliciesUser",
                newName: "IX_PoliciesUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyMenu_MenuId",
                table: "PoliciesMenu",
                newName: "IX_PoliciesMenu_MenuId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Password",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Email",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsInStock",
                table: "Products",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "PoliciesUser",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "PoliciesUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "PoliciesMenu",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PoliciesMenu",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PermissioId",
                table: "PoliciesMenu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "PoliciesMenu",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Policies",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Policies",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Policies",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Menus",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Menus",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Menus",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "SubCategory",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliciesUser",
                table: "PoliciesUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliciesMenu",
                table: "PoliciesMenu",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Policies",
                table: "Policies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesUser_PolicyId",
                table: "PoliciesUser",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesMenu_PolicyId",
                table: "PoliciesMenu",
                column: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesMenu_Menus_MenuId",
                table: "PoliciesMenu",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesMenu_Policies_PolicyId",
                table: "PoliciesMenu",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesUser_Policies_PolicyId",
                table: "PoliciesUser",
                column: "PolicyId",
                principalTable: "Policies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesUser_Users_UserId",
                table: "PoliciesUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
