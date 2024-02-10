using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAuctionSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                CREATE OR ALTER VIEW AuctionSummary (ListingTitle, StartingBid, CurrentBid, AuctionEnds, AuctionId) AS
                
                	SELECT 
                		a.[Name],
                		a.StartPrice,
                		dbo.GetMaxAuctionBet(a.Id),
                		a.EndDate,
                        a.Id
                	FROM 
                		Auctions AS a
                
                WITH CHECK OPTION
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS AuctionSummary");
        }
    }
}
