using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduhubDotnet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgrammeGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammeGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programme_ProgrammeGroup_ProgrammeGroupId",
                        column: x => x.ProgrammeGroupId,
                        principalTable: "ProgrammeGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Programme",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Language", "LastModifiedBy", "LastModifiedDate", "Name", "ProgrammeGroupId" },
                values: new object[] { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EN", null, null, "Applied Computer Science", null });

            migrationBuilder.InsertData(
                table: "ProgrammeGroup",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT Bachelors", null, null });

            migrationBuilder.InsertData(
                table: "Programme",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Language", "LastModifiedBy", "LastModifiedDate", "Name", "ProgrammeGroupId" },
                values: new object[,]
                {
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NL", null, null, "Toegepaste Informatica", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde") },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NL", null, null, "Elektronica-ICT", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programme_ProgrammeGroupId",
                table: "Programme",
                column: "ProgrammeGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programme");

            migrationBuilder.DropTable(
                name: "ProgrammeGroup");
        }
    }
}
