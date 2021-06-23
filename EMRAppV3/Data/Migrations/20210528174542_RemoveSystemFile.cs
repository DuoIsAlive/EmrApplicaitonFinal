using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMRAppV3.Data.Migrations
{
    public partial class RemoveSystemFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileOnFileSystem");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FileOnDatabaseModel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FileOnDatabaseModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "FileOnDatabaseModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "FileOnDatabaseModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FileOnDatabaseModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "FileOnDatabaseModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FileOnDatabaseModel");

            migrationBuilder.CreateTable(
                name: "FileOnFileSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileOnFileSystem", x => x.Id);
                });
        }
    }
}
