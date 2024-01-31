using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Core6.Migrations
{
    public partial class lehayo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Post",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Post",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefaultImage",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "DefaultImage",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Post");
        }
    }
}
