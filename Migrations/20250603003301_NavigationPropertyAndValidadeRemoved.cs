using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.API.Migrations
{
    /// <inheritdoc />
    public partial class NavigationPropertyAndValidadeRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Circulations_BookId",
                table: "Circulations",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Circulations_UserId",
                table: "Circulations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circulations_Books_BookId",
                table: "Circulations",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Circulations_Users_UserId",
                table: "Circulations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circulations_Books_BookId",
                table: "Circulations");

            migrationBuilder.DropForeignKey(
                name: "FK_Circulations_Users_UserId",
                table: "Circulations");

            migrationBuilder.DropIndex(
                name: "IX_Circulations_BookId",
                table: "Circulations");

            migrationBuilder.DropIndex(
                name: "IX_Circulations_UserId",
                table: "Circulations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Books");
        }
    }
}
