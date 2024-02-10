using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class RenameBetTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Bets",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Bets",
                newName: "Time");
        }
    }
}
