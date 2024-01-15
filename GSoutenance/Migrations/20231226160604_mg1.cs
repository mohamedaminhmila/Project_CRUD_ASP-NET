using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GSoutenance.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ensignant",
                columns: table => new
                {
                    EncadreurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensignant", x => x.EncadreurID);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateN = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.EtudiantId);
                });

            migrationBuilder.CreateTable(
                name: "Societe",
                columns: table => new
                {
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibSociete = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societe", x => x.SocieteID);
                });

            migrationBuilder.CreateTable(
                name: "Pfe",
                columns: table => new
                {
                    PFEID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    desc = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Dated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncadrantID = table.Column<int>(type: "int", nullable: false),
                    SocieteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfe", x => x.PFEID);
                    table.ForeignKey(
                        name: "FK_Pfe_Ensignant_EncadrantID",
                        column: x => x.EncadrantID,
                        principalTable: "Ensignant",
                        principalColumn: "EncadreurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pfe_Societe_SocieteID",
                        column: x => x.SocieteID,
                        principalTable: "Societe",
                        principalColumn: "SocieteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pfe_Etudiant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PFEID = table.Column<int>(type: "int", nullable: false),
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pfe_Etudiant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pfe_Etudiant_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalTable: "Etudiant",
                        principalColumn: "EtudiantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pfe_Etudiant_Pfe_PFEID",
                        column: x => x.PFEID,
                        principalTable: "Pfe",
                        principalColumn: "PFEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_EncadrantID",
                table: "Pfe",
                column: "EncadrantID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_SocieteID",
                table: "Pfe",
                column: "SocieteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_Etudiant_EtudiantId",
                table: "Pfe_Etudiant",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Pfe_Etudiant_PFEID",
                table: "Pfe_Etudiant",
                column: "PFEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pfe_Etudiant");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Pfe");

            migrationBuilder.DropTable(
                name: "Ensignant");

            migrationBuilder.DropTable(
                name: "Societe");
        }
    }
}
