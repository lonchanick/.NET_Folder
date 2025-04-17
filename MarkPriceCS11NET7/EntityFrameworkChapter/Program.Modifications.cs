
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Packt.Shared;

public partial class Program
{
    public static void ListProducts(int[]? productIdsToHighlight = null)
    {
        using (Northwind db = new())
        {
            if((db.Products is null)||(!db.Products.Any()))
            {
                Fail("There are no products");
                return;
            }
            WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |", "Id", "Product Name", "Cost", "Stock", "Disc.");
            foreach(var p in db.Products)
            {
                ConsoleColor previousColor = ForegroundColor;
                if ((productIdsToHighlight is not null) && productIdsToHighlight.Contains(p.ProductId))
                {
                    ForegroundColor = ConsoleColor.Green;
                }
                WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
                p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
                ForegroundColor = previousColor;
            }
        }
    }

    public static (int affected, int productId) AddProduct(int categoryId, string productName, decimal? price)
    {
        using(Northwind db = new())
        {
            if(db.Products is null) return (0,0);
            Product p = new()
            {
                CategoryId=categoryId,
                ProductName=productName,
                Cost=price
            };
            EntityEntry<Product> entity= db.Add(p);
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");
            
            int affected = db.SaveChanges();
            WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");
            return (affected, p.ProductId);
        }
    }
    public static (int affected, int productId) IncreaseProductPrice(string productNameStartsWith, decimal amount)
    {
        using(Northwind db = new ())
        {
            if(db.Products is null) return(0,0);
            Product p = db.Products
            .First(p=>p.ProductName.StartsWith(productNameStartsWith));
            
            WriteLine("Is this your product Y/N?\n");
            WriteLine(p);
            bool response = ReadKey(intercept:true).Key ==ConsoleKey.Y;
            if(response)
            {
                p.Cost+=amount;
                int affected = db.SaveChanges();
                return (affected, p.ProductId);
            }
            else
                WriteLine("Ok, try again with another prodcut name");

            return(0,0);
        }
    }
    
    public static int DeleteProducts(string productNameStartsWith)
    {
        using(Northwind db = new())
        {
            var products = db.Products
            .Where(p=>p.ProductName.StartsWith(productNameStartsWith)).ToList();

            if((products is null)||(!products.Any()))
            {
                Fail("Products not found!");
                return 0;
            }
            
            WriteLine("You are about to delete this product(s):");
            Product.TableMood(products!);
            Write("Are you sure to cotinue (Y/N)? ");
            if(ReadKey(intercept:true).Key==ConsoleKey.Y)
            {
                db.RemoveRange(products);
                int affected = db.SaveChanges();
                WriteLine("Changes done!");
                return affected;
            }

        }
        return 0;
    }

// public static (int affected, int[]? productIds) IncreaseProductPricesBetter(string productNameStartsWith, decimal amount)
// {

// }

}