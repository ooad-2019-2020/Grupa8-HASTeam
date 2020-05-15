using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HASRental.Models
{
    public class NasContext:IdentityDbContext<Korisnik,AppRole,int>
    {
        public NasContext(DbContextOptions<NasContext> options) : base(options)
        {

        }
        public DbSet<DetaljiRezervacije> DetaljiRezervacije { get; set; }
        public DbSet<FakturaRente> FakturaRente { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<Renta> Renta { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<TipRezervoara> TipRezervoara { get; set; }
        public DbSet<Vozilo> Vozilo { get; set; }
        public DbSet<VoziloKategorija> VoziloKategorija { get; set; }
        public DbSet<VoziloOprema> VoziloOprema { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DetaljiRezervacije>().ToTable("DetaljiRezervacije");
            modelBuilder.Entity<FakturaRente>().ToTable("FakturaRente");
            modelBuilder.Entity<Lokacija>().ToTable("Lokacija");
            modelBuilder.Entity<Proizvodjac>().ToTable("Proizvodjac");
            modelBuilder.Entity<Renta>().ToTable("Renta");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");
            modelBuilder.Entity<TipRezervoara>().ToTable("TipRezervoara");
            modelBuilder.Entity<Vozilo>().ToTable("Vozilo");
            modelBuilder.Entity<VoziloKategorija>().ToTable("VoziloKategorija");
            modelBuilder.Entity<VoziloOprema>().ToTable("VoziloOprema");
        }
    }
}
