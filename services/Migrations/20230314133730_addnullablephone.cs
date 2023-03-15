using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class addnullablephone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GardianInfos_PhoneTwo",
                table: "GardianInfos");

            migrationBuilder.DropIndex(
                name: "IX_FatherInfos_PhoneTwo",
                table: "FatherInfos");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTwo",
                table: "MotherInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTwo",
                table: "GardianInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTwo",
                table: "FatherInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_PhoneTwo",
                table: "GardianInfos",
                column: "PhoneTwo",
                unique: true,
                filter: "[PhoneTwo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_PhoneTwo",
                table: "FatherInfos",
                column: "PhoneTwo",
                unique: true,
                filter: "[PhoneTwo] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GardianInfos_PhoneTwo",
                table: "GardianInfos");

            migrationBuilder.DropIndex(
                name: "IX_FatherInfos_PhoneTwo",
                table: "FatherInfos");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTwo",
                table: "MotherInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTwo",
                table: "GardianInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneTwo",
                table: "FatherInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_PhoneTwo",
                table: "GardianInfos",
                column: "PhoneTwo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_PhoneTwo",
                table: "FatherInfos",
                column: "PhoneTwo",
                unique: true);
        }
    }
}
