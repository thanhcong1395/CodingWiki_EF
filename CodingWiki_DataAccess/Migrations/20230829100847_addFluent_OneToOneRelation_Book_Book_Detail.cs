using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addFluent_OneToOneRelation_Book_Book_Detail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "Fluent_BookDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetail_Book_Id",
                table: "Fluent_BookDetail",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetail_Fluent_Book_Book_Id",
                table: "Fluent_BookDetail",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetail_Fluent_Book_Book_Id",
                table: "Fluent_BookDetail");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetail_Book_Id",
                table: "Fluent_BookDetail");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Fluent_BookDetail");
        }
    }
}
