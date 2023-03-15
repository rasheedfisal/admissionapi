using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class newServerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MotherInfos_AdmId",
                table: "MotherInfos");

            migrationBuilder.DropIndex(
                name: "IX_MariageStatuses_AdmId",
                table: "MariageStatuses");

            migrationBuilder.DropIndex(
                name: "IX_GardianInfos_AdmId",
                table: "GardianInfos");

            migrationBuilder.DropIndex(
                name: "IX_FatherInfos_AdmId",
                table: "FatherInfos");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyInfos_AdmId",
                table: "EmergencyInfos");

            migrationBuilder.CreateIndex(
                name: "IX_MotherInfos_AdmId",
                table: "MotherInfos",
                column: "AdmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MariageStatuses_AdmId",
                table: "MariageStatuses",
                column: "AdmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_AdmId",
                table: "GardianInfos",
                column: "AdmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_AdmId",
                table: "FatherInfos",
                column: "AdmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyInfos_AdmId",
                table: "EmergencyInfos",
                column: "AdmId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MotherInfos_AdmId",
                table: "MotherInfos");

            migrationBuilder.DropIndex(
                name: "IX_MariageStatuses_AdmId",
                table: "MariageStatuses");

            migrationBuilder.DropIndex(
                name: "IX_GardianInfos_AdmId",
                table: "GardianInfos");

            migrationBuilder.DropIndex(
                name: "IX_FatherInfos_AdmId",
                table: "FatherInfos");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyInfos_AdmId",
                table: "EmergencyInfos");

            migrationBuilder.CreateIndex(
                name: "IX_MotherInfos_AdmId",
                table: "MotherInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_MariageStatuses_AdmId",
                table: "MariageStatuses",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_AdmId",
                table: "GardianInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_AdmId",
                table: "FatherInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyInfos_AdmId",
                table: "EmergencyInfos",
                column: "AdmId");
        }
    }
}
