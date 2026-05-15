using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoption.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAdoptionRequestKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_AspNetUsers_UserId",
                table: "AdoptionRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AdoptionRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_AspNetUsers_UserId",
                table: "AdoptionRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRequests_AspNetUsers_UserId",
                table: "AdoptionRequests");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AdoptionRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRequests_AspNetUsers_UserId",
                table: "AdoptionRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
