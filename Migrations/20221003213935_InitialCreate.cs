using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingInfo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    gender = table.Column<string>(nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    state = table.Column<string>(maxLength: 2, nullable: true),
                    zip = table.Column<string>(maxLength: 10, nullable: true),
                    email = table.Column<string>(nullable: true),
                    cell = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "address", "cell", "city", "email", "gender", "name", "state", "zip" },
                values: new object[] { 1, "555 madeup Street", "231-360-5236", "Traverse City", "greengregsandham@gmail.com", "male", "Greg", "MI", "49684" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");
        }
    }
}
