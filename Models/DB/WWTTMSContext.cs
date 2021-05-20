using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ceng396.Models.DB
{
    public partial class WWTTMSContext : DbContext
    {
        public WWTTMSContext()
        {
        }

        public WWTTMSContext(DbContextOptions<WWTTMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Crew> Crew { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BURAK;Database=WWTTMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasColumnName("Admin_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.AdminSurname)
                    .IsRequired()
                    .HasColumnName("Admin_Surname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.Property(e => e.CrewId).HasColumnName("Crew_ID");

                entity.Property(e => e.CrewAvailability).HasColumnName("Crew_Availability");

                entity.Property(e => e.CrewPassword).HasColumnName("Crew_Password");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.HasKey(e => e.SubId);

                entity.Property(e => e.SubId).HasColumnName("Sub_ID");

                entity.Property(e => e.SubAddress)
                    .IsRequired()
                    .HasColumnName("Sub_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.SubName)
                    .IsRequired()
                    .HasColumnName("Sub_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.SubPassword).HasColumnName("Sub_Password");

                entity.Property(e => e.SubSurname)
                    .IsRequired()
                    .HasColumnName("Sub_Surname")
                    .HasMaxLength(50);
                entity.Property(e => e.SubEmail)
                    .IsRequired()
                    .HasColumnName("Sub_Email")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("Ticket_ID");

                entity.Property(e => e.CrewId).HasColumnName("Crew_ID");

                entity.Property(e => e.SubId).HasColumnName("Sub_ID");

                entity.Property(e => e.TicketDone).HasColumnName("Ticket_Done");

                entity.Property(e => e.TicketMessage)
                    .IsRequired()
                    .HasColumnName("Ticket_Message")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Crew)
                 .WithMany(p => p.Ticket)
                 .HasForeignKey(d => d.CrewId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Ticket_Crew");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Subscriber");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
