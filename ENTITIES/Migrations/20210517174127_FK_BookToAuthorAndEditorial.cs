using Microsoft.EntityFrameworkCore.Migrations;

namespace ENTITIES.Migrations
{
    public partial class FK_BookToAuthorAndEditorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_IdAuthor",
                table: "Books",
                column: "IdAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdEditorial",
                table: "Books",
                column: "IdEditorial");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_IdAuthor",
                table: "Books",
                column: "IdAuthor",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Editorials_IdEditorial",
                table: "Books",
                column: "IdEditorial",
                principalTable: "Editorials",
                principalColumn: "IdEditorial",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_IdAuthor",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editorials_IdEditorial",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdAuthor",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdEditorial",
                table: "Books");
        }
    }
}
