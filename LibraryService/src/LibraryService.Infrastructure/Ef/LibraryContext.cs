using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryService.Infrastructure;
using LibraryService.Infrastructure.Settings;
using LibraryService.Core.Domain;

#nullable disable

namespace LibraryService.Infrastructure.Ef
{
    public partial class LibraryContext : DbContext
    {
        private readonly SqlSettings _settings;
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorNationality> AuthorNationalities { get; set; }
        public virtual DbSet<Edition> Editions { get; set; }
        public virtual DbSet<EditionTranslator> EditionTranslators { get; set; }
        public virtual DbSet<EditionHold> Editionholds { get; set; }
        public virtual DbSet<GenericResource> GenericResources { get; set; }
        public virtual DbSet<GenericResourceAuthor> GenericresourceAuthors { get; set; }
        public virtual DbSet<GenericResourceHold> Genericresourceholds { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Lease> Leases { get; set; }
        public virtual DbSet<Librarian> Librarians { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<ResourceInstance> Resourceinstances { get; set; }
        public virtual DbSet<ResourceInstanceHold> Resourceinstanceholds { get; set; }
        public virtual DbSet<ResourceType> Resourcetypes { get; set; }
        public virtual DbSet<Translator> Translators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_settings.ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("lastname");

                entity.Property(e => e.LeaseCounter)
                    .HasColumnType("mediumint(8) unsigned")
                    .HasColumnName("lease_counter")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .HasColumnName("password");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasDefaultValueSql("'10'");

                entity.Property(e => e.Salt)
                    .HasMaxLength(255)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.HasIndex(e => e.Fullname, "fullname");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("fullname");
            });

            modelBuilder.Entity<AuthorNationality>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.NationalityId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("author_nationality");

                entity.HasIndex(e => e.NationalityId, "nationality_id");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("author_id");

                entity.Property(e => e.NationalityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("nationality_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorNationalities)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_nationality_ibfk_1");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.AuthorNationalities)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_nationality_ibfk_2");
            });

            modelBuilder.Entity<Edition>(entity =>
            {
                entity.ToTable("edition");

                entity.HasIndex(e => e.GenericResourceId, "generic_resource_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DatePublished)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("date_published");

                entity.Property(e => e.GenericResourceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("generic_resource_id");

                entity.Property(e => e.Isbn13)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("isbn_13");

                entity.Property(e => e.Leaseable).HasColumnName("leaseable");

                entity.Property(e => e.Recompense)
                    .HasPrecision(19, 4)
                    .HasColumnName("recompense");

                entity.HasOne(d => d.GenericResource)
                    .WithMany(p => p.Editions)
                    .HasForeignKey(d => d.GenericResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edition_ibfk_1");
            });

            modelBuilder.Entity<EditionTranslator>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("edition_translator");

                entity.HasIndex(e => e.EditionId, "edition_id");

                entity.HasIndex(e => e.TranslatorId, "translator_id");

                entity.Property(e => e.EditionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("edition_id");

                entity.Property(e => e.TranslatorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("translator_id");

                entity.HasOne(d => d.Edition)
                    .WithMany()
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edition_translator_ibfk_1");

                entity.HasOne(d => d.Translator)
                    .WithMany()
                    .HasForeignKey(d => d.TranslatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edition_translator_ibfk_2");
            });

            modelBuilder.Entity<EditionHold>(entity =>
            {
                entity.ToTable("editionhold");

                entity.HasIndex(e => e.EditionId, "edition_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EditionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("edition_id");

                entity.Property(e => e.ResourceReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("resource_reservation_date");

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.Editionholds)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("editionhold_ibfk_1");
            });

            modelBuilder.Entity<GenericResource>(entity =>
            {
                entity.ToTable("genericresource");

                entity.HasIndex(e => e.GenericResourceName, "generic_resource_name");

                entity.HasIndex(e => e.ResourceType, "resource_type");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.GenericResourceName)
                    .IsRequired()
                    .HasColumnName("generic_resource_name");

                entity.Property(e => e.ResourceType)
                    .HasColumnType("int(11)")
                    .HasColumnName("resource_type");

                entity.HasOne(d => d.ResourceTypeNavigation)
                    .WithMany(p => p.Genericresources)
                    .HasForeignKey(d => d.ResourceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genericresource_ibfk_1");
            });

            modelBuilder.Entity<GenericResourceAuthor>(entity =>
            {
                entity.HasKey(e => new { e.GenericResourceId, e.AuthorId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("genericresource_author");

                entity.HasIndex(e => e.AuthorId, "author_id");

                entity.Property(e => e.GenericResourceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("generic_resource_id");

                entity.Property(e => e.AuthorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("author_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.GenericresourceAuthors)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genericresource_author_ibfk_2");

                entity.HasOne(d => d.GenericResource)
                    .WithMany(p => p.GenericresourceAuthors)
                    .HasForeignKey(d => d.GenericResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genericresource_author_ibfk_1");
            });

            modelBuilder.Entity<GenericResourceHold>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("genericresourcehold");

                entity.HasIndex(e => e.GenericResourceId, "generic_resource_id");

                entity.Property(e => e.GenericResourceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("generic_resource_id");

                entity.Property(e => e.ResourceReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("resource_reservation_date");

                entity.HasOne(d => d.GenericResource)
                    .WithMany()
                    .HasForeignKey(d => d.GenericResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("genericresourcehold_ibfk_1");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("institution");

                entity.HasIndex(e => e.InstitutionName, "institution_name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.InstitutionName).HasColumnName("institution_name");
            });

            modelBuilder.Entity<Lease>(entity =>
            {
                entity.ToTable("lease");

                entity.HasIndex(e => e.AccountId, "account_id");

                entity.HasIndex(e => e.LibrarianId, "librarian_id");

                entity.HasIndex(e => e.ResourceInstanceId, "resource_instance_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AccountId)
                    .HasColumnType("int(11)")
                    .HasColumnName("account_id");

                entity.Property(e => e.LeaseDuration)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("lease_duration");

                entity.Property(e => e.LeaseEnd)
                    .HasColumnType("date")
                    .HasColumnName("lease_end");

                entity.Property(e => e.LeaseStart)
                    .HasColumnType("date")
                    .HasColumnName("lease_start");

                entity.Property(e => e.LibrarianId)
                    .HasColumnType("int(11)")
                    .HasColumnName("librarian_id");

                entity.Property(e => e.ResourceInstanceId)
                    .IsRequired()
                    .HasMaxLength(17)
                    .HasColumnName("resource_instance_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Leases)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lease_ibfk_1");

                entity.HasOne(d => d.Librarian)
                    .WithMany(p => p.Leases)
                    .HasForeignKey(d => d.LibrarianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lease_ibfk_2");

                entity.HasOne(d => d.ResourceInstance)
                    .WithMany(p => p.Leases)
                    .HasForeignKey(d => d.ResourceInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("lease_ibfk_3");
            });

            modelBuilder.Entity<Librarian>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PRIMARY");

                entity.ToTable("librarian");

                entity.Property(e => e.AccountId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("account_id");

                entity.Property(e => e.AccessLevel)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("access_level");

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Librarian)
                    .HasForeignKey<Librarian>(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("librarian_ibfk_1");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationality");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(61)
                    .HasColumnName("country");
            });

            modelBuilder.Entity<ResourceInstance>(entity =>
            {
                entity.HasKey(e => e.ResourceCode)
                    .HasName("PRIMARY");

                entity.ToTable("resourceinstance");

                entity.HasIndex(e => e.EditionId, "edition_id");

                entity.HasIndex(e => e.InstitutionId, "institution_id");

                entity.Property(e => e.ResourceCode)
                    .HasMaxLength(17)
                    .HasColumnName("resource_code");

                entity.Property(e => e.EditionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("edition_id");

                entity.Property(e => e.InstitutionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("institution_id");

                entity.HasOne(d => d.Edition)
                    .WithMany(p => p.Resourceinstances)
                    .HasForeignKey(d => d.EditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resourceinstance_ibfk_1");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Resourceinstances)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resourceinstance_ibfk_2");
            });

            modelBuilder.Entity<ResourceInstanceHold>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("resourceinstancehold");

                entity.HasIndex(e => e.ResourceInstanceId, "resource_instance_id");

                entity.Property(e => e.ResourceInstanceId)
                    .IsRequired()
                    .HasMaxLength(17)
                    .HasColumnName("resource_instance_id");

                entity.Property(e => e.ResourceReservationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("resource_reservation_date");

                entity.HasOne(d => d.ResourceInstance)
                    .WithMany()
                    .HasForeignKey(d => d.ResourceInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("resourceinstancehold_ibfk_1");
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.ToTable("resourcetype");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(255)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<Translator>(entity =>
            {
                entity.ToTable("translator");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(60)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("lastname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
