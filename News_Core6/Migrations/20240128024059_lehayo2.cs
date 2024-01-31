using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Core6.Migrations
{
    public partial class lehayo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
