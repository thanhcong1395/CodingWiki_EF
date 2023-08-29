using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMappingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Authors_Book_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMap",
                newName: "Fluent_BookAuthorMaps");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMap_Book_Id",
                table: "Fluent_BookAuthorMaps",
                newName: "IX_Fluent_BookAuthorMaps_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMaps",
                table: "Fluent_BookAuthorMaps",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Authors_Book_Id",
                table: "Fluent_BookAuthorMaps",
                column: "Book_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMaps",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Authors_Book_Id",
                table: "Fluent_BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookAuthorMaps_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_BookAuthorMaps",
                table: "Fluent_BookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "Fluent_BookAuthorMaps",
                newName: "Fluent_BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_BookAuthorMaps_Book_Id",
                table: "Fluent_BookAuthorMap",
                newName: "IX_Fluent_BookAuthorMap_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_BookAuthorMap",
                table: "Fluent_BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Authors_Book_Id",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookAuthorMap_Fluent_Book_Book_Id",
                table: "Fluent_BookAuthorMap",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
