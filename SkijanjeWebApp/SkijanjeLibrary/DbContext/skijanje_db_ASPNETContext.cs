using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SkijanjeLibrary.FunctionModels;

namespace SkijanjeLibrary.Models
{
    public partial class skijanje_db_ASPNETContext : DbContext
    {
        public skijanje_db_ASPNETContext()
        {
        }

        public skijanje_db_ASPNETContext(DbContextOptions<skijanje_db_ASPNETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Instrukcija> Instrukcijas { get; set; } = null!;
        public virtual DbSet<Instruktor> Instruktors { get; set; } = null!;
        public virtual DbSet<Licenca> Licencas { get; set; } = null!;
        public virtual DbSet<Marka> Markas { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Oprema> Opremas { get; set; } = null!;
        public virtual DbSet<OpremaUcenik> OpremaUceniks { get; set; } = null!;
        public virtual DbSet<Ucenik> Uceniks { get; set; } = null!;

        public virtual DbSet<UcenikInstrukcija> UcenikInstrukcijas { get; set; }

        public virtual DbSet<InstrukcijaFM> InstrukcijaFMs { get; set; }
        public virtual DbSet<UcenikFM> UcenikFMs { get; set; }
        public virtual DbSet<KorisnickiNalog> KorisnickiNalogs { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=localhost;database=skijanje_db_ASPNET; Username=; Password=;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstrukcijaFM>(x => x.HasNoKey());
            modelBuilder.Entity<UcenikFM>(x => x.HasNoKey());

            modelBuilder.Entity<KorisnickiNalog>(entity =>
            {
                entity.ToTable("korisnickinalog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.Property(e => e.Password).HasColumnName("password");

            });

            modelBuilder.Entity<Instrukcija>(entity =>
            {
                entity.ToTable("instrukcija");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Biljeske).HasColumnName("biljeske");

                entity.Property(e => e.BrojCas).HasColumnName("broj_cas");

                entity.Property(e => e.DatumOdr)
                    .HasColumnType("date")
                    .HasColumnName("datum_odr");

                entity.Property(e => e.Instruktorid).HasColumnName("instruktorid");

                entity.Property(e => e.Termin)
                    .HasColumnType("time(6) without time zone")
                    .HasColumnName("termin");

                entity.HasOne(d => d.Instruktor)
                    .WithMany(p => p.Instrukcijas)
                    .HasForeignKey(d => d.Instruktorid)
                    .HasConstraintName("fkinstrukcij844282");
            });

            modelBuilder.Entity<Instruktor>(entity =>
            {
                entity.ToTable("instruktor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Biografija)
                    .HasMaxLength(255)
                    .HasColumnName("biografija");

                entity.Property(e => e.Cv).HasColumnName("cv");

                entity.Property(e => e.DatRodj)
                    .HasColumnType("date")
                    .HasColumnName("dat_rodj");

                entity.Property(e => e.Ime)
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.KontaktTel)
                    .HasMaxLength(50)
                    .HasColumnName("kontakt_tel");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(100)
                    .HasColumnName("prezime");

                entity.Property(e => e.SkijIsk)
                    .HasColumnType("date")
                    .HasColumnName("skij_isk");

                entity.Property(e => e.Spol)
                    .HasMaxLength(10)
                    .HasColumnName("spol");

            });

            modelBuilder.Entity<Licenca>(entity =>
            {
                entity.ToTable("licenca");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Instruktorid).HasColumnName("instruktorid");

                entity.Property(e => e.LicencaId)
                    .HasMaxLength(255)
                    .HasColumnName("licenca_id");

                entity.Property(e => e.NazivLicence)
                    .HasMaxLength(50)
                    .HasColumnName("naziv_licence");

                entity.Property(e => e.Opis)
                    .HasMaxLength(255)
                    .HasColumnName("opis");

                entity.HasOne(d => d.Instruktor)
                    .WithMany(p => p.Licencas)
                    .HasForeignKey(d => d.Instruktorid)
                    .HasConstraintName("fklicenca261033");
            });

            modelBuilder.Entity<Marka>(entity =>
            {
                entity.ToTable("marka");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("model");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Oprema>(entity =>
            {
                entity.ToTable("oprema");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Markaid).HasColumnName("markaid");

                entity.Property(e => e.Modelid).HasColumnName("modelid");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .HasColumnName("naziv");

                entity.HasOne(d => d.Marka)
                    .WithMany(p => p.Opremas)
                    .HasForeignKey(d => d.Markaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fkoprema08012022");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Opremas)
                    .HasForeignKey(d => d.Modelid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fkoprema16012022");
            });

            modelBuilder.Entity<OpremaUcenik>(entity =>
            {
                entity.ToTable("oprema_ucenik");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatIzd).HasColumnName("dat_izd");

                entity.Property(e => e.Instrukcijaid).HasColumnName("instrukcijaid");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Opremaid).HasColumnName("opremaid");

                entity.Property(e => e.Ucenikid).HasColumnName("ucenikid");

                entity.HasOne(d => d.Instrukcija)
                    .WithMany(p => p.OpremaUceniks)
                    .HasForeignKey(d => d.Instrukcijaid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fkoprema_uce08012022");

                entity.HasOne(d => d.Oprema)
                    .WithMany(p => p.OpremaUceniks)
                    .HasForeignKey(d => d.Opremaid)
                    .HasConstraintName("fkoprema_uce22379");

                entity.HasOne(d => d.Ucenik)
                    .WithMany(p => p.OpremaUceniks)
                    .HasForeignKey(d => d.Ucenikid)
                    .HasConstraintName("fkoprema_uce295950");
            });

            modelBuilder.Entity<Ucenik>(entity =>
            {
                entity.ToTable("ucenik");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatRodj).HasColumnName("dat_rodj");

                entity.Property(e => e.Ime)
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.KontaktTel)
                    .HasMaxLength(50)
                    .HasColumnName("kontakt_tel");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(100)
                    .HasColumnName("prezime");

                entity.Property(e => e.Spol)
                    .HasMaxLength(10)
                    .HasColumnName("spol");

              
            });

            modelBuilder.Entity<UcenikInstrukcija>(entity =>
            {
                entity.HasKey(e => new { e.Ucenikid, e.Instrukcijaid })
                    .HasName("ucenik_instrukcija_pkey");

                entity.ToTable("ucenik_instrukcija");

                entity.Property(e => e.Ucenikid).HasColumnName("ucenikid");

                entity.Property(e => e.Instrukcijaid).HasColumnName("instrukcijaid");

                entity.HasOne(d => d.Instrukcija)
                    .WithMany(p => p.UcenikInstrukcijas)
                    .HasForeignKey(d => d.Instrukcijaid)
                    .HasConstraintName("fkucenik_ins644940");

                entity.HasOne(d => d.Ucenik)
                    .WithMany(p => p.UcenikInstrukcijas)
                    .HasForeignKey(d => d.Ucenikid)
                    .HasConstraintName("fkucenik_ins700545");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
