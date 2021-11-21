using Microsoft.EntityFrameworkCore.Migrations;

namespace SportStoreApi.Migrations
{
    public partial class catagoryAddedToItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Catagory",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Catagory",
                table: "Items");
        }
    }
}
