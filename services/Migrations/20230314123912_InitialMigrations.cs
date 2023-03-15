using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionIndex = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyInfos_Admission_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Admission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FatherInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FatherInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FatherInfos_Admission_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Admission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GardianInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardianInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GardianInfos_Admission_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Admission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MariageStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MRStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MariageStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MariageStatuses_Admission_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Admission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneOne = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneTwo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherInfos_Admission_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Admission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthCrt = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PassportCrt = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DocOne = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DocTwo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInfos_Admission_AdmId",
                        column: x => x.AdmId,
                        principalTable: "Admission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyInfos_AdmId",
                table: "EmergencyInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_AdmId",
                table: "FatherInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_Email",
                table: "FatherInfos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_FirstName_SecondName_MiddleName_Surname",
                table: "FatherInfos",
                columns: new[] { "FirstName", "SecondName", "MiddleName", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_PhoneOne",
                table: "FatherInfos",
                column: "PhoneOne",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatherInfos_PhoneTwo",
                table: "FatherInfos",
                column: "PhoneTwo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_AdmId",
                table: "GardianInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_Email",
                table: "GardianInfos",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_FirstName_SecondName_MiddleName_Surname",
                table: "GardianInfos",
                columns: new[] { "FirstName", "SecondName", "MiddleName", "Surname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_PhoneOne",
                table: "GardianInfos",
                column: "PhoneOne",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardianInfos_PhoneTwo",
                table: "GardianInfos",
                column: "PhoneTwo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MariageStatuses_AdmId",
                table: "MariageStatuses",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherInfos_AdmId",
                table: "MotherInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherInfos_FullName",
                table: "MotherInfos",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_AdmId",
                table: "StudentInfos",
                column: "AdmId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_Name_AdmId",
                table: "StudentInfos",
                columns: new[] { "Name", "AdmId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergencyInfos");

            migrationBuilder.DropTable(
                name: "FatherInfos");

            migrationBuilder.DropTable(
                name: "GardianInfos");

            migrationBuilder.DropTable(
                name: "MariageStatuses");

            migrationBuilder.DropTable(
                name: "MotherInfos");

            migrationBuilder.DropTable(
                name: "StudentInfos");

            migrationBuilder.DropTable(
                name: "Admission");
        }
    }
}
