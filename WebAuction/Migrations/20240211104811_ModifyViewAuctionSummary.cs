using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAuction.Migrations
{
    /// <inheritdoc />
    public partial class ModifyViewAuctionSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                """
                 CREATE OR ALTER VIEW AuctionSummary (ImageData, ListingTitle, StartingBid, CurrentBid, AuctionEnds, AuctionId) AS
 
                    	SELECT 
                			i.[Data],
                       		a.[Name],
                       		a.StartPrice,
                       		dbo.GetMaxAuctionBet(a.Id),
                       		a.EndDate,
                         a.Id
                    	FROM 
                       		Auctions AS a
                		LEFT JOIN Images AS i ON
                			i.AuctionId = a.Id
                		WHERE i.IsMain = 1
                 
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
