using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingInfo.Migrations
{
    public partial class inita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceName = table.Column<string>(nullable: false),
                    years = table.Column<int>(nullable: false),
                    freq = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "Gear",
                columns: table => new
                {
                    GearId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetupName = table.Column<string>(nullable: false),
                    Shoes = table.Column<string>(nullable: true),
                    Harness = table.Column<string>(nullable: true),
                    Chalk_Bag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear", x => x.GearId);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    city = table.Column<string>(maxLength: 30, nullable: true),
                    state = table.Column<string>(maxLength: 2, nullable: true),
                    zip = table.Column<string>(maxLength: 10, nullable: true),
                    email = table.Column<string>(nullable: false),
                    cell = table.Column<string>(nullable: true),
                    ExperienceId = table.Column<int>(nullable: false),
                    GearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Membership_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Gear_GearId",
                        column: x => x.GearId,
                        principalTable: "Gear",
                        principalColumn: "GearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "ExperienceId", "ExperienceName", "freq", "years" },
                values: new object[,]
                {
                    { 1, "Gregs exp", "2-3 days a week!", 1 },
                    { 2, "More exp", "twice a week.", 5 },
                    { 3, "Others sxp", "7 days a week!", 1 },
                    { 4, "Mine exp", "1 day a month.", 20 }
                });

            migrationBuilder.InsertData(
                table: "Gear",
                columns: new[] { "GearId", "Chalk_Bag", "Harness", "SetupName", "Shoes" },
                values: new object[,]
                {
                    { 1, "Custom", "Black Diamond Momentum", "Fun setup", "Scarpa Helix" },
                    { 2, "Cotopaxi", "Mammut Ophir", "Mitch", "La Sportiva Tarantulace" },
                    { 3, "Kavu Peak Seeker", "petzl Corax", "Berrygood", "evolv Shaman" },
                    { 4, "Static Waxed", "Wild Country Session", "aggressive set", "Black Diamond Momentum" },
                    { 5, "8BPLUS Lilly", "Arc'teryx Konseal", "Medium setup", "Butora Gomi" }
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "ID", "ExperienceId", "GearId", "address", "cell", "city", "email", "Gender", "Name", "state", "zip" },
                values: new object[,]
                {
                    { 1, 1, 1, "555 madeup Street", "231-360-5236", "Traverse City", "greengregsandham@gmail.com", "male", "Greg", "MI", "49684" },
                    { 5, 2, 1, "555 madeup Street", "231-360-5236", "Traverse City", "JamwithJamalle@gmail.com", "undisclosed", "Jamalle", "MI", "49684" },
                    { 6, 1, 1, "555 madeup Street", "231-360-5236", "Traverse City", "greengregggggsandham@gmail.com", "male", "Gregggggg", "MI", "49684" },
                    { 7, 1, 1, "555 madeup Street", "231-360-5236", "Traverse City", "Lucy2022@gmail.com", "female", "Lucy", "MI", "49684" },
                    { 2, 2, 2, "555 madeup Street", "231-360-5236", "Traverse City", "Bobbytown@bob.com", "male", "Bob", "MI", "49684" },
                    { 3, 1, 3, "555 madeup Street", "231-360-5236", "Traverse City", "dontditchmitch@gmail.com", "wizard", "Mitch", "MI", "49684" },
                    { 8, 4, 3, "555 madeup Street", "231-360-5236", "Traverse City", "Craigisloud@gmail.com", "male", "Craig", "MI", "49684" },
                    { 4, 3, 5, "555 madeup Street", "231-360-5236", "Traverse City", "Utridisavalidname@gmail.com", "female", "Utrid", "MI", "49684" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membership_ExperienceId",
                table: "Membership",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_GearId",
                table: "Membership",
                column: "GearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Gear");
        }
    }
}
