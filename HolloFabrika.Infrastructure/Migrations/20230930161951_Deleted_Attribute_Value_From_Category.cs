using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HolloFabrika.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Deleted_Attribute_Value_From_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Attributes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Attributes",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
