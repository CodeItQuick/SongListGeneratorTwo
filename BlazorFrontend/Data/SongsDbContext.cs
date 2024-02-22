using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Application.Adapter;

public sealed class SongsDbContext : DbContext
{
    public DbSet<SongsDbo> Songs { get; set; }
    public DbSet<ArtistMbTag> ArtistMbTags { get; set; }
    private readonly string _connectionString;

    public SongsDbContext()
    {
        Database.SetCommandTimeout(9000);
    }

    public SongsDbContext(DbContextOptions<SongsDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\..\\artist_term.db";
            optionsBuilder.UseSqlite($"Data Source={directory}", 
                sqlLiteOptions => sqlLiteOptions.CommandTimeout(600));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SongsDbo>()
            .HasMany(e => e.ArtistMbTags)
            .WithOne(e => e.SongsDbo)
            .HasPrincipalKey(e => e.artist_id)
            .HasForeignKey(e => e.artist_id);
    }
}

public class ExpenseContextFactory : IDesignTimeDbContextFactory<SongsDbContext>
{
    public SongsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SongsDbContext>();
        var directory = AppDomain.CurrentDomain.BaseDirectory + "track_metadata.db";
        optionsBuilder.UseSqlite($"Data Source={directory}");

        return new SongsDbContext(optionsBuilder.Options);
    }
}
