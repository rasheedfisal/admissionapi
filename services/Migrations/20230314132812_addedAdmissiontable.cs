﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace services.Migrations
{
    /// <inheritdoc />
    public partial class addedAdmissiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Admission_AdmissionIndex",
                table: "Admission",
                column: "AdmissionIndex",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Admission_AdmissionIndex",
                table: "Admission");
        }
    }
}
