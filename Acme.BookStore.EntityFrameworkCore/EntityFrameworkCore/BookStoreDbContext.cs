using Acme.BookStore.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Acme.BookStore.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class BookStoreDbContext : 
    AbpDbContext<BookStoreDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<IdentityUser> Users => throw new System.NotImplementedException();

    public DbSet<IdentityRole> Roles => throw new System.NotImplementedException();

    public DbSet<IdentityClaimType> ClaimTypes => throw new System.NotImplementedException();

    public DbSet<OrganizationUnit> OrganizationUnits => throw new System.NotImplementedException();

    public DbSet<IdentitySecurityLog> SecurityLogs => throw new System.NotImplementedException();

    public DbSet<IdentityLinkUser> LinkUsers => throw new System.NotImplementedException();

    public DbSet<IdentityUserDelegation> UserDelegations => throw new System.NotImplementedException();

    public DbSet<IdentitySession> Sessions => throw new System.NotImplementedException();

    public DbSet<Tenant> Tenants => throw new System.NotImplementedException();

    public DbSet<TenantConnectionString> TenantConnectionStrings => throw new System.NotImplementedException();

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Book>(b =>
        {
            b.ToTable(BookStoreConsts.DbTablePrefix + "Books",
                BookStoreConsts.DbSchema);
            
            b.ConfigureByConvention(); // Auto-configure base class properties (like Id, CreationTime, etc.)

            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(128);
        });
    }
}
