using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispas_Vlad_Traian_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class FixedAddingAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Author",
                newName: "AuthorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Author",
                newName: "ID");
        }
    }
}
