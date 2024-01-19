using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace piAssignment.Migrations
{
    /// <inheritdoc />
    public partial class updateUserInfostableremovefirstNamelastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserInfos");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "UserInfos",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserInfos",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
