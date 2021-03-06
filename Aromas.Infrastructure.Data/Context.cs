using Aromas.Domain.Entities;
using Aromas.Domain.Entities.Permissions;
using Aromas.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Aromas.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> builderOptions)
            : base(builderOptions)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyUser> PoliciesUser { get; set; }
        public DbSet<PolicyMenu> PoliciesMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping(builder.Entity<User>());
            new ProductMapping(builder.Entity<Product>());
            new CategoryMapping(builder.Entity<Category>());    
            new MenuMapping(builder.Entity<Menu>());
            new PolicyMapping(builder.Entity<Policy>());
            new PolicyMenuMapping(builder.Entity<PolicyMenu>());
            new PolicyUserMapping(builder.Entity<PolicyUser>());

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=tcp:aromasdesenvolvimento.database.windows.net,1433;Initial Catalog=Aromas_DB;Persist Security Info=False;User ID=aromas;Password=Admin123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        private void SetDateTimeNow()
        {
            var newEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            newEntities.ForEach(x =>
            {
                var propertieName = "CreatedAt";

                if (x.Metadata.FindProperty(propertieName) != null)
                    x.Property(propertieName).CurrentValue = DateTime.Now;
            });

            var modifiedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();
            modifiedEntities.ForEach(x =>
            {
                var propertieName = "UpdatedAt";

                if (x.Metadata.FindProperty(propertieName) != null)
                    x.Property(propertieName).CurrentValue = DateTime.Now;
            });
        }
        public override int SaveChanges()
        {
            SetDateTimeNow();
            return base.SaveChanges();
        }
    }
}
