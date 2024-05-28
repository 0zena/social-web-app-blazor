using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Likes",
                newName: "PostID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                newName: "IX_Likes_PostID");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Posts",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostID",
                table: "Likes",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostID",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "Likes",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostID",
                table: "Likes",
                newName: "IX_Likes_PostId");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Posts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
