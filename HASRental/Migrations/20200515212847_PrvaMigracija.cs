using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HASRental.Migrations
{
    public partial class PrvaMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodenja = table.Column<DateTime>(nullable: false),
                    BrojVozacke = table.Column<string>(nullable: true),
                    DatumIzdavanjaVozacke = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(nullable: true),
                    Grad = table.Column<string>(nullable: true),
                    Kanton = table.Column<string>(nullable: true),
                    Drazava = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipRezervoara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipRezervoara", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoziloKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    CijenaRente = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoziloKategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PocetnaLokacijaId = table.Column<int>(nullable: true),
                    KrajnjaLokacijaId = table.Column<int>(nullable: true),
                    VoziloKategorijaId = table.Column<int>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Lokacija_KrajnjaLokacijaId",
                        column: x => x.KrajnjaLokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Lokacija_PocetnaLokacijaId",
                        column: x => x.PocetnaLokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_VoziloKategorija_VoziloKategorijaId",
                        column: x => x.VoziloKategorijaId,
                        principalTable: "VoziloKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vozilo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoziloKategorijaId = table.Column<int>(nullable: true),
                    ProizvodjacId = table.Column<int>(nullable: true),
                    TrenutnaLokacijaId = table.Column<int>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    GodinaProizvodnje = table.Column<DateTime>(nullable: false),
                    Kilometraza = table.Column<int>(nullable: false),
                    Boja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozilo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vozilo_Proizvodjac_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vozilo_Lokacija_TrenutnaLokacijaId",
                        column: x => x.TrenutnaLokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vozilo_VoziloKategorija_VoziloKategorijaId",
                        column: x => x.VoziloKategorijaId,
                        principalTable: "VoziloKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetaljiRezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervacijaId = table.Column<int>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    MjestoDolaska = table.Column<string>(nullable: true),
                    OcekivanoVrijemeDolaska = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaljiRezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaljiRezervacije_Rezervacija_RezervacijaId",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Renta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(nullable: true),
                    VoziloId = table.Column<int>(nullable: true),
                    PocetnaLokacijaId = table.Column<int>(nullable: true),
                    KrajnjaLokacijaId = table.Column<int>(nullable: true),
                    DatumRentanja = table.Column<DateTime>(nullable: false),
                    DatumVracanja = table.Column<DateTime>(nullable: false),
                    DodatneNaznake = table.Column<string>(nullable: true),
                    TipRezervoaraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renta_AspNetUsers_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renta_Lokacija_KrajnjaLokacijaId",
                        column: x => x.KrajnjaLokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renta_Lokacija_PocetnaLokacijaId",
                        column: x => x.PocetnaLokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Renta_TipRezervoara_TipRezervoaraId",
                        column: x => x.TipRezervoaraId,
                        principalTable: "TipRezervoara",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Renta_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoziloOprema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoziloId = table.Column<int>(nullable: true),
                    OpisOpreme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoziloOprema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoziloOprema_Vozilo_VoziloId",
                        column: x => x.VoziloId,
                        principalTable: "Vozilo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FakturaRente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentaId = table.Column<int>(nullable: true),
                    CijenaRente = table.Column<double>(nullable: false),
                    Taksa = table.Column<double>(nullable: false),
                    Pdv = table.Column<double>(nullable: false),
                    UkupniIznos = table.Column<double>(nullable: false),
                    IznosPopusta = table.Column<double>(nullable: false),
                    NetoIznos = table.Column<double>(nullable: false),
                    TipPlacanja = table.Column<string>(nullable: true),
                    Placeno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakturaRente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FakturaRente_Renta_RentaId",
                        column: x => x.RentaId,
                        principalTable: "Renta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetaljiRezervacije_RezervacijaId",
                table: "DetaljiRezervacije",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_FakturaRente_RentaId",
                table: "FakturaRente",
                column: "RentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_KorisnikId",
                table: "Renta",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_KrajnjaLokacijaId",
                table: "Renta",
                column: "KrajnjaLokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_PocetnaLokacijaId",
                table: "Renta",
                column: "PocetnaLokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_TipRezervoaraId",
                table: "Renta",
                column: "TipRezervoaraId");

            migrationBuilder.CreateIndex(
                name: "IX_Renta_VoziloId",
                table: "Renta",
                column: "VoziloId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikId",
                table: "Rezervacija",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KrajnjaLokacijaId",
                table: "Rezervacija",
                column: "KrajnjaLokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_PocetnaLokacijaId",
                table: "Rezervacija",
                column: "PocetnaLokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_VoziloKategorijaId",
                table: "Rezervacija",
                column: "VoziloKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_ProizvodjacId",
                table: "Vozilo",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_TrenutnaLokacijaId",
                table: "Vozilo",
                column: "TrenutnaLokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vozilo_VoziloKategorijaId",
                table: "Vozilo",
                column: "VoziloKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_VoziloOprema_VoziloId",
                table: "VoziloOprema",
                column: "VoziloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetaljiRezervacije");

            migrationBuilder.DropTable(
                name: "FakturaRente");

            migrationBuilder.DropTable(
                name: "VoziloOprema");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Renta");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TipRezervoara");

            migrationBuilder.DropTable(
                name: "Vozilo");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropTable(
                name: "VoziloKategorija");
        }
    }
}
