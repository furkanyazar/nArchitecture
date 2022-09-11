using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kodlama.io.Devs.Persistence.Migrations
{
    public partial class AddSocialMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "SocialMediaType", "Url", "UserId" },
                values: new object[] { 1, 0, "https://github.com/furkanyazar", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 83, 58, 23, 62, 81, 103, 245, 86, 248, 221, 8, 8, 167, 95, 192, 249, 233, 6, 168, 60, 213, 205, 139, 90, 105, 119, 177, 250, 180, 90, 46, 184, 4, 80, 114, 23, 41, 184, 31, 66, 122, 187, 107, 94, 110, 190, 145, 111, 84, 229, 66, 166, 227, 166, 25, 39, 37, 6, 157, 153, 250, 90, 40, 62 }, new byte[] { 89, 200, 60, 4, 208, 74, 139, 225, 223, 217, 120, 125, 24, 172, 95, 195, 36, 189, 86, 84, 155, 74, 252, 213, 25, 175, 172, 162, 205, 129, 79, 59, 237, 130, 209, 61, 191, 177, 40, 0, 234, 76, 32, 93, 187, 125, 66, 54, 28, 65, 183, 80, 161, 88, 47, 140, 111, 146, 58, 219, 123, 84, 14, 211, 75, 245, 75, 23, 201, 166, 198, 207, 12, 192, 87, 146, 181, 151, 118, 46, 123, 245, 174, 212, 161, 110, 130, 113, 168, 171, 229, 0, 190, 12, 36, 221, 3, 253, 18, 40, 164, 130, 222, 175, 174, 108, 35, 12, 175, 207, 155, 126, 213, 38, 67, 192, 201, 20, 8, 215, 223, 132, 92, 158, 195, 186, 104, 164 } });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UserId",
                table: "SocialMedias",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 36, 236, 41, 188, 248, 60, 71, 4, 166, 99, 224, 146, 210, 188, 83, 223, 157, 135, 52, 67, 35, 217, 44, 47, 110, 242, 209, 109, 63, 237, 26, 116, 203, 20, 221, 225, 10, 168, 16, 170, 175, 64, 235, 240, 192, 144, 209, 172, 189, 255, 92, 164, 129, 247, 32, 17, 132, 159, 185, 33, 227, 253, 218, 41 }, new byte[] { 62, 212, 172, 170, 230, 186, 9, 123, 43, 133, 240, 104, 255, 152, 145, 114, 206, 28, 2, 137, 125, 158, 209, 92, 78, 152, 231, 61, 60, 206, 214, 84, 87, 16, 244, 151, 179, 12, 245, 5, 84, 97, 166, 39, 1, 247, 192, 132, 36, 67, 237, 115, 94, 27, 162, 245, 134, 212, 89, 139, 4, 240, 56, 192, 3, 154, 177, 67, 50, 217, 105, 62, 155, 170, 216, 20, 232, 106, 122, 71, 235, 41, 112, 39, 227, 49, 7, 216, 148, 131, 186, 29, 14, 235, 220, 11, 16, 34, 222, 241, 219, 58, 50, 7, 221, 32, 181, 254, 54, 32, 58, 60, 248, 53, 163, 194, 48, 33, 53, 76, 86, 61, 137, 106, 221, 254, 202, 161 } });
        }
    }
}
