using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoAlbum.DAL.Migrations
{
    public partial class FixedImagePathAccordingToTheImageUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "images\\Forest.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Photos",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "images/Forest.jpg");
        }
    }
}
