using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLabo.Migrations
{
    public partial class init_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AffinityChamp",
                columns: table => new
                {
                    IdAffinityChamp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weak = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Strong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffinityChamp", x => x.IdAffinityChamp);
                });

            migrationBuilder.CreateTable(
                name: "BasicStatistic",
                columns: table => new
                {
                    IdBasicsStatistic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    Atk = table.Column<int>(type: "int", nullable: false),
                    Def = table.Column<int>(type: "int", nullable: false),
                    Vit = table.Column<int>(type: "int", nullable: false),
                    CriticalRate = table.Column<int>(type: "int", nullable: false),
                    CriticalDamage = table.Column<int>(type: "int", nullable: false),
                    Resistor = table.Column<int>(type: "int", nullable: false),
                    Precision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicStatistic", x => x.IdBasicsStatistic);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    IdEquipment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NbPartsRequired = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.IdEquipment);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(384)", maxLength: 384, nullable: false),
                    Passwd = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Rule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaltKey = table.Column<byte[]>(type: "varbinary(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Champ",
                columns: table => new
                {
                    IdChamp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BasicsStatisticsIdBasicsStatistic = table.Column<int>(type: "int", nullable: true),
                    AffinityIdAffinityChamp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champ", x => x.IdChamp);
                    table.ForeignKey(
                        name: "FK_Champ_AffinityChamp_AffinityIdAffinityChamp",
                        column: x => x.AffinityIdAffinityChamp,
                        principalTable: "AffinityChamp",
                        principalColumn: "IdAffinityChamp");
                    table.ForeignKey(
                        name: "FK_Champ_BasicStatistic_BasicsStatisticsIdBasicsStatistic",
                        column: x => x.BasicsStatisticsIdBasicsStatistic,
                        principalTable: "BasicStatistic",
                        principalColumn: "IdBasicsStatistic");
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    IdSkill = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Effect = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ChampEntityIdChamp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.IdSkill);
                    table.ForeignKey(
                        name: "FK_Skill_Champ_ChampEntityIdChamp",
                        column: x => x.ChampEntityIdChamp,
                        principalTable: "Champ",
                        principalColumn: "IdChamp");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champ_AffinityIdAffinityChamp",
                table: "Champ",
                column: "AffinityIdAffinityChamp");

            migrationBuilder.CreateIndex(
                name: "IX_Champ_BasicsStatisticsIdBasicsStatistic",
                table: "Champ",
                column: "BasicsStatisticsIdBasicsStatistic");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ChampEntityIdChamp",
                table: "Skill",
                column: "ChampEntityIdChamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Champ");

            migrationBuilder.DropTable(
                name: "AffinityChamp");

            migrationBuilder.DropTable(
                name: "BasicStatistic");
        }
    }
}
