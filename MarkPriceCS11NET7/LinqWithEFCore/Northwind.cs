using Microsoft.EntityFrameworkCore;
using Packt.Shared;

public class Northwind : DbContext
{
    public Northwind(){}

    public DbSet<Category> Categories{get; set;} =null!;
    public DbSet<Product> Products{get; set;}=null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(Environment.CurrentDirectory,"Northwind.db");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if ((Database.ProviderName is not null) && (Database.ProviderName.Contains("Sqlite")))
        {
            modelBuilder.Entity<Product>()
            .Property(product => product.UnitPrice)
            .HasConversion<double>();
        }
    }

}