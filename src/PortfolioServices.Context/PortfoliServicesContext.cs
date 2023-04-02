using Microsoft.EntityFrameworkCore;
using PortfolioServices.Model;

namespace PortfolioServices.Context;

public partial class PortfoliServicesContext : DbContext
{
    public PortfoliServicesContext(DbContextOptions<PortfoliServicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }
    public virtual DbSet<Home> Homes { get; set; }
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<About> Abouts { get; set; }
    public virtual DbSet<ImageUtilities> ImageUtilities { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientComment> ClientComments { get; set; }
    public virtual DbSet<SocialLink> SocialLink { get; set; }
    public virtual DbSet<Portfolio> Portfolio { get; set; }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(configuration["PortfolioService:ConnectionString"]);
    //}

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

        modelBuilder.Entity<About>(entity =>
        {
            entity.ToTable("About");

            entity.HasKey(e => e.Tid)
                .HasName("PK__About__C451DB316FD4FD35");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ImageUtilities>(entity =>
        {
            entity.ToTable("ImageUtilities");

            entity.HasKey(e => e.Tid)
                .HasName("PK__ImageUti__C451DB314368339E");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ServiceDetail>(entity =>
        {
            entity.ToTable("ServiceDetail");

            entity.HasKey(e => e.Tid)
                .HasName("PK__Service__C451DB3116E848A2");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });
        
        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.HasKey(e => e.Tid)
                .HasName("PK__Service__C451DB317F567A7C");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");
            
            entity.HasKey(e => e.Tid).HasName("PK__Client__C451DB3133FE2D2E");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<ClientComment>(entity =>
        {
            entity.ToTable("ClientComment");

            entity.HasKey(e => e.Tid).HasName("PK__ClientCo__C451DB31158A6414");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<SocialLink>(entity =>
        {
            entity.ToTable("SocialLink");

            entity.HasKey(e => e.Tid).HasName("PK__SocicalL__C451DB319E559516");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Url).IsUnicode(false);
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.ToTable("Portfolio");

            entity.HasKey(e => e.Tid).HasName("PK__Portfoli__C451DB3160CD4011");

            entity.Property(e => e.Tid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.SubTitle).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Title).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
