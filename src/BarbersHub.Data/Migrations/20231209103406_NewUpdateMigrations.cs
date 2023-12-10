using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbersHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_BarberStyles_BarberStyleId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BarberStyles_BarberStyleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_BarberStyles_BarberStyleId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "BarberStyles");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "BarberStyles");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BarberStyles");

            migrationBuilder.RenameColumn(
                name: "BarberStyleId",
                table: "Favorites",
                newName: "StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_BarberStyleId",
                table: "Favorites",
                newName: "IX_Favorites_StyleId");

            migrationBuilder.RenameColumn(
                name: "BarberStyleId",
                table: "Comments",
                newName: "StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BarberStyleId",
                table: "Comments",
                newName: "IX_Comments_StyleId");

            migrationBuilder.RenameColumn(
                name: "BarberStyleId",
                table: "Assets",
                newName: "StyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_BarberStyleId",
                table: "Assets",
                newName: "IX_Assets_StyleId");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Styles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "Styles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Styles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Styles_StyleId",
                table: "Assets",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Styles_StyleId",
                table: "Comments",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Styles_StyleId",
                table: "Favorites",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Styles_StyleId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Styles_StyleId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Styles_StyleId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Styles");

            migrationBuilder.RenameColumn(
                name: "StyleId",
                table: "Favorites",
                newName: "BarberStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_StyleId",
                table: "Favorites",
                newName: "IX_Favorites_BarberStyleId");

            migrationBuilder.RenameColumn(
                name: "StyleId",
                table: "Comments",
                newName: "BarberStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_StyleId",
                table: "Comments",
                newName: "IX_Comments_BarberStyleId");

            migrationBuilder.RenameColumn(
                name: "StyleId",
                table: "Assets",
                newName: "BarberStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_StyleId",
                table: "Assets",
                newName: "IX_Assets_BarberStyleId");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "BarberStyles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "BarberStyles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "BarberStyles",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_BarberStyles_BarberStyleId",
                table: "Assets",
                column: "BarberStyleId",
                principalTable: "BarberStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BarberStyles_BarberStyleId",
                table: "Comments",
                column: "BarberStyleId",
                principalTable: "BarberStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_BarberStyles_BarberStyleId",
                table: "Favorites",
                column: "BarberStyleId",
                principalTable: "BarberStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
