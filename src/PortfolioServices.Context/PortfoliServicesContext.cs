using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortfolioServices.Model;

namespace PortfolioServices.Context;

public partial class PortfoliServicesContext : DbContext
{
    private readonly IConfiguration configuration;

    public PortfoliServicesContext(DbContextOptions<PortfoliServicesContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    public virtual DbSet<Categories> Categories { get; set; }
    public virtual DbSet<Home> Homes { get; set; }
    public virtual DbSet<Language> Languages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration["PortfolioService:ConnectionString"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>(entity =>
        {
            entity.ToTable("Categories");

            entity.HasKey(e => e.Tid).HasName("PK__Categori__C451DB31389BBF3C");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Object).HasMaxLength(30).IsUnicode(false);
        });

        modelBuilder.Entity<Home>(entity =>
        {
            entity.ToTable("Home");

            entity.HasKey(e => e.Tid)
                .HasName("PK__Home__C451DB313287FC55");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.HasKey(e => e.Tid)
                .HasName("PK__Language__C451DB31BE3A07D0");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.Object)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
