using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace upgradedfis.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationships1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Works_WorkId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Works_WorkId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Companies_CompanyId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Stagings_StagingId",
                table: "Works");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Works_WorkId",
                table: "Comments",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Works_WorkId",
                table: "Notifications",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Companies_CompanyId",
                table: "Works",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Stagings_StagingId",
                table: "Works",
                column: "StagingId",
                principalTable: "Stagings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Works_WorkId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Works_WorkId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Companies_CompanyId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Stagings_StagingId",
                table: "Works");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Works_WorkId",
                table: "Comments",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Works_WorkId",
                table: "Notifications",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Companies_CompanyId",
                table: "Works",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Employees_EmployeeId",
                table: "Works",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Stagings_StagingId",
                table: "Works",
                column: "StagingId",
                principalTable: "Stagings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
