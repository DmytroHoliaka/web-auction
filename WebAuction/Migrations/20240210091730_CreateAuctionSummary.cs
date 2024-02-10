using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class CreateAuctionSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                CREATE OR ALTER FUNCTION GetMaxAuctionBet
                (
                	@AuctionId UNIQUEIDENTIFIER
                )
                RETURNS DECIMAL(10,2)
                AS
                BEGIN
                	DECLARE @MaxBet DECIMAL(10,2);
                
                	SELECT 
                		@MaxBet = Max(Price)
                	FROM
                		Bets
                	WHERE
                		AuctionId = @AuctionId;
                
                	RETURN @MaxBet;
                END;
                """);

            migrationBuilder.Sql(
                """
                CREATE OR ALTER VIEW AuctionSummary (ListingTitle, StartingBid, CurrentBid, AuctionEnds) AS
                
                	SELECT 
                		a.[Name],
                		a.StartPrice,
                		dbo.GetMaxAuctionBet(a.Id),
                		a.EndDate
                	FROM 
                		Auctions AS a
                
                WITH CHECK OPTION
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS AuctionSummary");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS GetMaxAuctionBet");
        }
    }
}
