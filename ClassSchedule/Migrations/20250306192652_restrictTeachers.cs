using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ch12Ex1ClassSchedule.Migrations
{
    /// <inheritdoc />
    public partial class restrictTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_TeacherId",
                table: "Classes");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1,
                column: "MilitaryTime",
                value: "1500");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 6,
                column: "DayId",
                value: 5);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_TeacherId",
                table: "Classes",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_TeacherId",
                table: "Classes");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1,
                column: "MilitaryTime",
                value: "1100");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 6,
                column: "DayId",
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_TeacherId",
                table: "Classes",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
