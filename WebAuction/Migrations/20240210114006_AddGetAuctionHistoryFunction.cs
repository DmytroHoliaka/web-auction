using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class AddGetAuctionHistoryFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                CREATE OR ALTER FUNCTION GetAuctionHistory
                (
                	@AuctionId UNIQUEIDENTIFIER
                )
                RETURNS Table
                AS
                RETURN 
                	SELECT 
                		u.Username AS Username,
                		b.Price AS Bid,
                		b.[Date] AS [Date],
                		b.Id AS BetId
                	FROM 
                		Bets AS b
                	INNER JOIN Users AS u ON
                		u.Id = b.UserId
                	WHERE
                		b.AuctionId = @AuctionId;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS GetAuctionHistory;");
        }
    }
}
