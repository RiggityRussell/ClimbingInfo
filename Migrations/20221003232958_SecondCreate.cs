using Microsoft.EntityFrameworkCore.Migrations;

namespace ClimbingInfo.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    years = table.Column<int>(nullable: false),
                    freq = table.Column<string>(maxLength: 50, nullable: true),
                    MembersID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Experience_Membership_MembersID",
                        column: x => x.MembersID,
                        principalTable: "Membership",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experience",
                columns: new[] { "ID", "MembersID", "freq", "years" },
                values: new object[] { 1, 1, "2-3 days a week!", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Experience_MembersID",
                table: "Experience",
                column: "MembersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experience");
        }
    }
}
