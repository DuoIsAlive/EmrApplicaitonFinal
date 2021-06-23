using Microsoft.EntityFrameworkCore.Migrations;

namespace EMRAppV3.Data.Migrations
{
    public partial class NullDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_AspNetUsers_ApplicationUserId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ApplicationUserId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId",
                unique: true,
                filter: "[DoctorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DocotorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Doctor",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ApplicationUserId",
                table: "Doctor",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_AspNetUsers_ApplicationUserId",
                table: "Doctor",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
