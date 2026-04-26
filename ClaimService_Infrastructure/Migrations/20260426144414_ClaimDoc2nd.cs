using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClaimService_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClaimDoc2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ClaimDocs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ClaimDocs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ClaimDocs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "ClaimDocs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClaimDocs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClaimDocs");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClaimDocs");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClaimDocs");
        }
    }
}
