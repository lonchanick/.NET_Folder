using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;//wtf is this?
using Packt.Shared;
// using Microsoft.EntityFrameworkCore.ChangeTracking; //CollectionEntry

partial class Program
{
    public static void QueryingCategories()
    {
        using (Northwind db = new())
        {
            IQueryable<Category>? categories; // = NorthWindDB.Categories;
            // ?.Include(c => c.Products); //coment this to test the lazy loading pattern and explicit loading pattern
           

            db.ChangeTracker.LazyLoadingEnabled=false;

            Write("\nEnable Eager loading Y/N?");
            bool eagerLoading = ReadKey(intercept:true).Key == ConsoleKey.Y;

            bool explicitLoading = false;

            if(eagerLoading)
            {
                categories = db.Categories.Include(c => c.Products);
            }else
            {
                categories = db.Categories;
                Write("\nEnable Explicit loading Y/N?");
                explicitLoading = ReadKey(intercept:true).Key == ConsoleKey.Y;
            }
            // bool explicitOption;
            
            if(explicitLoading)
            {
                WriteLine("\nExplicit Loading is: {0} so ...",explicitLoading);
                foreach(var c in categories)
                {
                    Write($"\nExplicit Products loading for category {c.CategoryName} Y/N?");
                    // explicitOption = ReaKey(intercept:true).Key == ConsoleKey.Y;
                    ConsoleKeyInfo key = ReadKey(intercept: true);
                    if(key.Key == ConsoleKey.Y)
                    {   
                        /**/
                        //wtf is this
                        CollectionEntry<Category, Product> products =
                        db.Entry(c).Collection(c2 => c2.Products);
                        if (!products.IsLoaded) products.Load();
                        /**/
                        foreach(Product? p in products.CurrentValue!)
                            WriteLine(p);
                        
                    }

                }
            }


            // Info(categories?.ToQueryString()??"NullQueryString");
            
            // if(categories is null || !categories.Any())
            // {
            // Fail("No Category(ies) Found") ;
            // return;
            // }

            // foreach(var c in categories)
            //     WriteLine("categoty {0} has {1} products", c.CategoryName, c.Products.Count());
        }
        
    }
    public static void FilteredIncludes()
    {
        string input;
        int amountParsed;

        do{
            Write("Enter minimun amount in stock required: ");
            input = ReadLine()!;
        }while(!int.TryParse(input, out amountParsed));
        
        
        using(Northwind dbcontext = new())
            {
                IQueryable<Category>? categories = dbcontext.Categories?
                .Include(c => c.Products.Where(p => p.Stock >= amountParsed));
                // IQueryable<Category>? categories = db.Categories?
                // .Include(c => c.Products.Where(p => p.Stock >= stock));

                Info(categories?.ToQueryString()??"NullQueryString");
                
            
                if((categories is null) || (!categories.Any()))
                {
                    Fail("Error - fail operation");
                }

                WriteLine("\nMinimal amount {0}",amountParsed);
                foreach(var c in categories!)
                {
                    WriteLine("categoty: {0} has {1} products", c.CategoryName, c.Products.Count());
                    foreach(Product p in c.Products)
                        WriteLine("\tAmount({0}) - {1}",p.Stock,p.ProductName);
                }
            }
    }
    public static void QueryingProducts()
    {
        string input;
        decimal inputOut;
        do
        {
            Write("Enter a price: ");
            input=ReadLine()!;
        }while(!decimal.TryParse(input, out inputOut));

        using (Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?
            .TagWith("Products with higher price than ..")
            .Where(p => p.Cost > inputOut);

            Info(products?.ToQueryString()??"NullQueryString");

            if((products is null)||(!products.Any()))
            {
                Fail("No product found.");
                return;
            }


            WriteLine("Products with higher price than {0:$#,##0.00}:\n", inputOut);
            foreach(var p in products!)
                WriteLine("Product: {0}\nPrice: {1:$#,##0.00}\nStock: {2}\n", p.ProductName, p.Cost,p.Stock);
        }
    }

    public static void QueryingWithLike()
    {

        string input;
        Write("Searching product: ");
        input =ReadLine()!;
        if(string.IsNullOrEmpty(input))
        {
            WriteLine("Bad request"); 
            return;
        }
        
        using(Northwind db = new())
        {
            IQueryable<Product>? queryResult = db.Products?
            .Where(p => EF.Functions.Like(p.ProductName,$"%{input}%"));

            if((queryResult is null) || (!queryResult.Any()))
            {
                WriteLine("No product found");
            }

            foreach(Product p in queryResult!)
                WriteLine(p);
                // WriteLine($"\nProduct: {p.ProductName}\nDeprecated: {p.Discontinued}\n");
        }
    }
    public static void GetRandomProduct()
    {
        using (Northwind db = new())
        {
            WriteLine("\tGetting a random record from products");
            int? countProduct = db.Products?.Count();
            
            if(countProduct is null)
            {
                Fail("Data base table is empty");
                return;
            }

            var p = db.Products!
            .FirstOrDefault(p => p.ProductId == (int)(EF.Functions.Random() * countProduct));

            if(p is null)
            {
                Fail($"Product Id: {countProduct} does not exist");
                return;
            }
            Fail("Product Found!");
            WriteLine(p);


        }
    }
}