using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yemek_ismi = table.Column<string>(type: "varchar(40)", nullable: false),
                    protein_yüzde = table.Column<int>(type: "int", nullable: false),
                    yağ_yüzde = table.Column<int>(type: "int", nullable: false),
                    karbonhidrat_yüzde = table.Column<int>(type: "int", nullable: false),
                    kalori = table.Column<int>(type: "int", nullable: false),
                    protein_gr = table.Column<int>(type: "int", nullable: false),
                    yağ_gr = table.Column<int>(type: "int", nullable: false),
                    karbonhidrat_gr = table.Column<int>(type: "int", nullable: false),
                    sodyum_gr = table.Column<int>(type: "int", nullable: false),
                    potasyum_gr = table.Column<int>(type: "int", nullable: false),
                    kalsiyum_gr = table.Column<int>(type: "int", nullable: false),
                    lif_gr = table.Column<int>(type: "int", nullable: false),
                    kollestrol_gr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(30)", nullable: false),
                    Soyad = table.Column<string>(type: "varchar(30)", nullable: false),
                    Eposta = table.Column<string>(type: "varchar(30)", nullable: false),
                    Sifre = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    buzdolabı_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.id);
                    table.ForeignKey(
                        name: "FK_Fridges_Users_id",
                        column: x => x.id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "My_Foods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    yemek_no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_My_Foods", x => x.id);
                    table.ForeignKey(
                        name: "FK_My_Foods_Foods_yemek_no",
                        column: x => x.yemek_no,
                        principalTable: "Foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_My_Foods_Fridges_id",
                        column: x => x.id,
                        principalTable: "Fridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_buzdolabı_id",
                table: "Fridges",
                column: "buzdolabı_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_My_Foods_yemek_no",
                table: "My_Foods",
                column: "yemek_no",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Eposta",
                table: "Users",
                column: "Eposta",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "My_Foods");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
