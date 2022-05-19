using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
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
                    protein_yüzde = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    yağ_yüzde = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    karbonhidrat_yüzde = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    kalori = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    protein_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    yağ_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    karbonhidrat_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    sodyum_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    potasyum_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    kalsiyum_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    lif_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    kollestrol_gr = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    gün_bozulma_tarihi = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
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
                    Sifre = table.Column<string>(type: "varchar(30)", nullable: false),
                    Cinsiyet = table.Column<string>(type: "varchar(15)", nullable: true, defaultValue: "Belirtmemiş"),
                    Telefon = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(15)", nullable: true, defaultValue: "Buzdolabım")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.id);
                    table.ForeignKey(
                        name: "FK_Fridges_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    tercih_eposta = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    tercih_uygulama = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    tercih_sms = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                    table.ForeignKey(
                        name: "FK_Notification_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_articles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(500)", nullable: false),
                    date = table.Column<string>(type: "varchar(30)", nullable: true, defaultValue: "18.05.2022 11:47:25"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_articles", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_articles_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "My_Foods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fridges_id = table.Column<int>(type: "int", nullable: false),
                    Foods_id = table.Column<int>(type: "int", nullable: false),
                    eklenme_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 18, 11, 47, 25, 994, DateTimeKind.Local).AddTicks(5122)),
                    bozulma_tarihi = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 18, 11, 47, 25, 993, DateTimeKind.Local).AddTicks(3089))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_My_Foods", x => x.id);
                    table.ForeignKey(
                        name: "FK_My_Foods_Foods_Foods_id",
                        column: x => x.Foods_id,
                        principalTable: "Foods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_My_Foods_Fridges_Fridges_id",
                        column: x => x.Fridges_id,
                        principalTable: "Fridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_user_id",
                table: "Fridges",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_My_Foods_Foods_id",
                table: "My_Foods",
                column: "Foods_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_My_Foods_Fridges_id",
                table: "My_Foods",
                column: "Fridges_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_user_id",
                table: "Notification",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_articles_user_id",
                table: "User_articles",
                column: "user_id");

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
                name: "Notification");

            migrationBuilder.DropTable(
                name: "User_articles");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
