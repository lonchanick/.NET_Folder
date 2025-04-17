

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace Packt.Shared;
public class Northwind: DbContext
{
    public Northwind(){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string DbFilePath = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
        string filenameParameter=$"Filename={DbFilePath}";

        // ConsoleColor previousColor = ForegroundColor;
        // ForegroundColor = ConsoleColor.DarkYellow;
        // WriteLine("CurrentConeccion: {0}", filenameParameter);
        // ForegroundColor= previousColor;

        optionsBuilder.UseSqlite(filenameParameter);

        //enables to write sensitive log data to the console 
        //optionsBuilder.LogTo(WriteLine, new[]{RelationalEventId.CommandExecuting}).EnableSensitiveDataLogging();
        
    }
    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}
    

    // example of using Fluent API instead of attributes
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // example of using Fluent API instead of attributes
        // to limit the length of a category name to 15
        modelBuilder.Entity<Category>()
        .Property(p => p.CategoryName)
        .IsRequired()
        .HasMaxLength(15);

        // added to "fix" the lack of decimal support in SQLite
        if(Database.ProviderName?.Contains("Sqlite")?? false)
        {
            // added to "fix" the lack of decimal support in SQLite
            modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .HasConversion<double>();
        }

        //Defining global filters.
        // Northwind products can be discontinued, so it might be useful to ensure that discontinued products are
        // never returned in results, even if the programmer does not use Where to filter them out in their queries
        modelBuilder.Entity<Product>()
        .HasQueryFilter(p=>!p.Discontinued);

    }
    
}
