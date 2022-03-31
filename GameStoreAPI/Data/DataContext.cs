using GameStore.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }

    // SETS WHICH FIELD IS THE KEY AND THAT IT SHOULD GENERATE ITSELF WHEN ADDING RECORDS
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(etb =>
        {
            etb.HasKey(etb => etb.Id);
            etb.Property(etb => etb.Id).ValueGeneratedOnAdd();
        });

        base.OnModelCreating(modelBuilder);
    }
}