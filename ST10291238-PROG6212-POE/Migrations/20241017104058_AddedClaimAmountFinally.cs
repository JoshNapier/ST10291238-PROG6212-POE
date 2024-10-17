using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ST10291238_PROG6212_POE.Migrations
{
    /// <inheritdoc />
    public partial class AddedClaimAmountFinally : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ClaimAmount",
                table: "Claims",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimAmount",
                table: "Claims");
        }
    }
}
