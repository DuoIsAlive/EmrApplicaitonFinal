using Microsoft.EntityFrameworkCore.Migrations;

namespace EMRAppV3.Data.Migrations
{
    public partial class UsersFileReleshionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "FileOnDatabaseModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FileOnDatabaseModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileOnDatabaseModel_ApplicationUserId",
                table: "FileOnDatabaseModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileOnDatabaseModel_AspNetUsers_ApplicationUserId",
                table: "FileOnDatabaseModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileOnDatabaseModel_AspNetUsers_ApplicationUserId",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropIndex(
                name: "IX_FileOnDatabaseModel_ApplicationUserId",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FileOnDatabaseModel");
        }
    }
}
