using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyJWTApi.Migrations
{
    public partial class jwtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.User_id);
                });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "User_id", "Address", "Age", "Email_id", "Mobile_no", "Password", "Role", "User_name" },
                values: new object[] { 1, "sector 25 delhi", 20, "varun@abc.com", "9897124588", "Varun@1234", "Admin", "varun" });

            migrationBuilder.InsertData(
                table: "UserDetails",
                columns: new[] { "User_id", "Address", "Age", "Email_id", "Mobile_no", "Password", "Role", "User_name" },
                values: new object[] { 2, "sector 20 delhi", 22, "Nikhil@abc.com", "9897125599", "Nikhil@1234", "User", "Nikhil" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
