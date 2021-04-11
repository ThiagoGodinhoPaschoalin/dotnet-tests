using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SharedDomain.Configurations;
using SharedDomain.Models;
using SharedDomain.Models.Associative;
using SharedDomain.Models.Enums;

namespace Ef5Domain.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        { }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<AccountProfile> GetAssociativeAccountProfile { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>(model =>
            {
                model.ToTable("account");
                model.HasKey(x => x.Id).HasName("PK_Account_Id").IsClustered();
                model.Property(x => x.FirstName).IsRequired().HasMaxLength(100).ValueGeneratedNever();
                model.Property(x => x.LastName).IsRequired().HasMaxLength(100).ValueGeneratedNever();
                model.Property(x => x.Document).IsRequired().HasMaxLength(30).ValueGeneratedNever();
                model.HasAlternateKey(x => x.Document).HasName("AK_Account_Document");
                model.Property(x => x.Gender).IsRequired().HasConversion(new EnumToNumberConverter<GenderType, byte>());
            });
            modelBuilder.Entity<ProfileModel>(model =>
            {
                model.ToTable("profile");
                model.HasKey(x => x.Id).HasName("PK_Profile_Id").IsClustered();
                model.Property(x => x.Name).IsRequired().HasMaxLength(100).ValueGeneratedNever();
            });
            modelBuilder.Entity<AccountProfile>(model =>
            {
                model.ToTable("account_profile");
                model.HasKey(x => x.Id).HasName("PK_AccountProfile_Id");
                model.HasAlternateKey(x => new { x.AccountId, x.ProfileId }).HasName("AK_AccountProfile_AccountIdProfileId").IsClustered();

                model.HasOne(x => x.Account).WithMany(x => x.Profiles).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Cascade);
                model.HasOne(x => x.Profile).WithMany(x => x.Accounts).HasForeignKey(x => x.ProfileId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AccountModel>()
                .HasData(SeedData.GetAccounts());
            modelBuilder.Entity<ProfileModel>()
                .HasData(SeedData.GetProfiles());
            modelBuilder.Entity<AccountProfile>()
                .HasData(SeedData.GetAssociativeAccountProfiles());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}