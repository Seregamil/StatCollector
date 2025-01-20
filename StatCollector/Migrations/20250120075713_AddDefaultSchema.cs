using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatCollector.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stat_collector");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "stat_collector");

            migrationBuilder.RenameTable(
                name: "pipelines",
                newName: "pipelines",
                newSchema: "stat_collector");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "stat_collector",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "pipelines",
                schema: "stat_collector",
                newName: "pipelines");
        }
    }
}
