using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibrary1.Migrations
{
    public partial class latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BrojOsoba",
                columns: table => new
                {
                    BrojOsobaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brOsoba = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojOsoba", x => x.BrojOsobaID);
                });

            migrationBuilder.CreateTable(
                name: "KapacitetStola",
                columns: table => new
                {
                    KapacitetStolaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    minBrStolica = table.Column<int>(nullable: false),
                    maxBrStolica = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KapacitetStola", x => x.KapacitetStolaID);
                });

            migrationBuilder.CreateTable(
                name: "Nalog",
                columns: table => new
                {
                    NalogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Lozinka = table.Column<string>(maxLength: 50, nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalog", x => x.NalogID);
                });

            migrationBuilder.CreateTable(
                name: "TerminRezervacije",
                columns: table => new
                {
                    TerminRezervacijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    terminRez = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminRezervacije", x => x.TerminRezervacijeID);
                });

            migrationBuilder.CreateTable(
                name: "TipProizvoda",
                columns: table => new
                {
                    TipProizvodaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipProizvoda", x => x.TipProizvodaID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    ulogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivUloge = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.ulogaID);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(nullable: false),
                    NalogID = table.Column<int>(nullable: true),
                    VrijemeKreiranja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Token_Nalog_NalogID",
                        column: x => x.NalogID,
                        principalTable: "Nalog",
                        principalColumn: "NalogID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlogaID = table.Column<int>(nullable: true),
                    ime = table.Column<string>(maxLength: 64, nullable: false),
                    prezime = table.Column<string>(maxLength: 64, nullable: false),
                    brojTelefona = table.Column<string>(maxLength: 20, nullable: false),
                    adresaStanovanja = table.Column<string>(maxLength: 64, nullable: false),
                    NalogID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Nalog_NalogID",
                        column: x => x.NalogID,
                        principalTable: "Nalog",
                        principalColumn: "NalogID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Uloga_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "ulogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    VrijemePocetka = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatID);
                    table.ForeignKey(
                        name: "FK_Chat_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    EmailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    EmailAdresa = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    VrijemeSlanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.EmailID);
                    table.ForeignKey(
                        name: "FK_Email_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentar",
                columns: table => new
                {
                    KomentarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sadrzaj = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    VrijemePostavljanja = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentar", x => x.KomentarID);
                    table.ForeignKey(
                        name: "FK_Komentar_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Konekcija",
                columns: table => new
                {
                    KonekcijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Vrijednost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konekcija", x => x.KonekcijaID);
                    table.ForeignKey(
                        name: "FK_Konekcija_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poslovnica",
                columns: table => new
                {
                    PoslovnicaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poslovnica", x => x.PoslovnicaID);
                    table.ForeignKey(
                        name: "FK_Poslovnica_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slika",
                columns: table => new
                {
                    SlikaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slika = table.Column<byte[]>(nullable: true),
                    datumPostavljanja = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: true),
                    lokacijaSlike = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slika", x => x.SlikaID);
                    table.ForeignKey(
                        name: "FK_Slika_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 64, nullable: true),
                    Prezime = table.Column<string>(maxLength: 64, nullable: true),
                    BrojTelefona = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    DatumRezervacije = table.Column<string>(nullable: true),
                    VrijemeZahtjeva = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(maxLength: 256, nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    TerminRezervacijeID = table.Column<int>(nullable: true),
                    PoslovnicaID = table.Column<int>(nullable: true),
                    BrojOsobaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_BrojOsoba_BrojOsobaID",
                        column: x => x.BrojOsobaID,
                        principalTable: "BrojOsoba",
                        principalColumn: "BrojOsobaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Poslovnica_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnica",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_TerminRezervacije_TerminRezervacijeID",
                        column: x => x.TerminRezervacijeID,
                        principalTable: "TerminRezervacije",
                        principalColumn: "TerminRezervacijeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stol",
                columns: table => new
                {
                    StolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dostupan = table.Column<bool>(nullable: false),
                    PoslovnicaID = table.Column<int>(nullable: true),
                    KapacitetStolaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stol", x => x.StolID);
                    table.ForeignKey(
                        name: "FK_Stol_KapacitetStola_KapacitetStolaID",
                        column: x => x.KapacitetStolaID,
                        principalTable: "KapacitetStola",
                        principalColumn: "KapacitetStolaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stol_Poslovnica_PoslovnicaID",
                        column: x => x.PoslovnicaID,
                        principalTable: "Poslovnica",
                        principalColumn: "PoslovnicaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ObavijestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlikaID = table.Column<int>(nullable: true),
                    Naslov = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    VrijemeObjave = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ObavijestID);
                    table.ForeignKey(
                        name: "FK_Obavijest_Slika_SlikaID",
                        column: x => x.SlikaID,
                        principalTable: "Slika",
                        principalColumn: "SlikaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obavijest_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlikaID = table.Column<int>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 64, nullable: false),
                    Opis = table.Column<string>(maxLength: 256, nullable: false),
                    Cijena = table.Column<double>(nullable: false),
                    TipProizvodaID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvod_Slika_SlikaID",
                        column: x => x.SlikaID,
                        principalTable: "Slika",
                        principalColumn: "SlikaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proizvod_TipProizvoda_TipProizvodaID",
                        column: x => x.TipProizvodaID,
                        principalTable: "TipProizvoda",
                        principalColumn: "TipProizvodaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proizvod_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UserID",
                table: "Chat",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Email_UserID",
                table: "Email",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Komentar_UserID",
                table: "Komentar",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Konekcija_UserID",
                table: "Konekcija",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_SlikaID",
                table: "Obavijest",
                column: "SlikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_UserID",
                table: "Obavijest",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Poslovnica_UserID",
                table: "Poslovnica",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_SlikaID",
                table: "Proizvod",
                column: "SlikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_TipProizvodaID",
                table: "Proizvod",
                column: "TipProizvodaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_UserID",
                table: "Proizvod",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_BrojOsobaID",
                table: "Rezervacija",
                column: "BrojOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PoslovnicaID",
                table: "Rezervacija",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_TerminRezervacijeID",
                table: "Rezervacija",
                column: "TerminRezervacijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_UserID",
                table: "Rezervacija",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Slika_UserID",
                table: "Slika",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Stol_KapacitetStolaID",
                table: "Stol",
                column: "KapacitetStolaID");

            migrationBuilder.CreateIndex(
                name: "IX_Stol_PoslovnicaID",
                table: "Stol",
                column: "PoslovnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_NalogID",
                table: "Token",
                column: "NalogID");

            migrationBuilder.CreateIndex(
                name: "IX_User_NalogID",
                table: "User",
                column: "NalogID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UlogaID",
                table: "User",
                column: "UlogaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Komentar");

            migrationBuilder.DropTable(
                name: "Konekcija");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Stol");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Slika");

            migrationBuilder.DropTable(
                name: "TipProizvoda");

            migrationBuilder.DropTable(
                name: "BrojOsoba");

            migrationBuilder.DropTable(
                name: "TerminRezervacije");

            migrationBuilder.DropTable(
                name: "KapacitetStola");

            migrationBuilder.DropTable(
                name: "Poslovnica");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Nalog");

            migrationBuilder.DropTable(
                name: "Uloga");
        }
    }
}
