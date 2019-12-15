using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectApp.Migrations
{
    public partial class Crowdo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCode = table.Column<string>(nullable: true),
                    UserCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    PackageCode = table.Column<string>(nullable: true),
                    NumberOfRequestedPackages = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectItemId);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fundings",
                columns: table => new
                {
                    FundingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCode = table.Column<string>(nullable: true),
                    ProjectCode = table.Column<string>(nullable: true),
                    PackageCode = table.Column<string>(nullable: true),
                    NumberOfPackages = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ProjectItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundings", x => x.FundingId);
                    table.ForeignKey(
                        name: "FK_Fundings_Projects_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalTable: "Projects",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fundings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackagesAsking",
                columns: table => new
                {
                    PackageItemAskingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Rewards = table.Column<string>(nullable: true),
                    ProjectItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagesAsking", x => x.PackageItemAskingId);
                    table.ForeignKey(
                        name: "FK_PackagesAsking_Projects_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalTable: "Projects",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackagesReceived",
                columns: table => new
                {
                    PackageItemReceivedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageItemAskingId = table.Column<int>(nullable: true),
                    ProjectItemId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagesReceived", x => x.PackageItemReceivedId);
                    table.ForeignKey(
                        name: "FK_PackagesReceived_PackagesAsking_PackageItemAskingId",
                        column: x => x.PackageItemAskingId,
                        principalTable: "PackagesAsking",
                        principalColumn: "PackageItemAskingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackagesReceived_Projects_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalTable: "Projects",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PackagesReceived_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fundings_ProjectItemId",
                table: "Fundings",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Fundings_UserId",
                table: "Fundings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesAsking_ProjectItemId",
                table: "PackagesAsking",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesReceived_PackageItemAskingId",
                table: "PackagesReceived",
                column: "PackageItemAskingId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesReceived_ProjectItemId",
                table: "PackagesReceived",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagesReceived_UserId",
                table: "PackagesReceived",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fundings");

            migrationBuilder.DropTable(
                name: "PackagesReceived");

            migrationBuilder.DropTable(
                name: "PackagesAsking");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
