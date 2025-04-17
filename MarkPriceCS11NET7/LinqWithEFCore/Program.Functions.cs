
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Packt.Shared;

partial class Program
{
    static void FilterAndSord()
    {
        using(Northwind db = new())
        {
            DbSet<Product> allProducts = db.Products;

            IQueryable<Product> productsFiltered = allProducts
            .Where(p => p.UnitPrice < 10M);

            IOrderedQueryable<Product> sortedAndFilteredProducts = productsFiltered
            .OrderByDescending(p => p.UnitPrice);
            
            var prod = sortedAndFilteredProducts
            .Select(p=>new{
                p.ProductId,
                p.ProductName,
                p.UnitPrice
            });

            WriteLine(prod.ToQueryString());

            WriteLine("Products that cost les than $10");
            foreach (var p in prod)
            {
                WriteLine("{0}: {1} costs {2:$#,##0.00}",p.ProductId, p.ProductName, p.UnitPrice);
            }
            WriteLine();
        }
    }

    static void JoinCategoryProduct()
    {
        using(var db = new Northwind())
        {
            var queryJoin = db.Categories
            .Join(
                inner: db.Products,
                outerKeySelector: category => category.CategoryId,
                innerKeySelector: product => product.CategoryId,
                resultSelector: (c,p)=> new {c.CategoryName, p.ProductName, p.ProductId}
            ).Take(3);

            // var result = queryJoin.Take(3);
            foreach (var item in queryJoin)
            {
                WriteLine("{0}: {1} is in {2}.",
                arg0: item.ProductId,
                arg1: item.ProductName,
                arg2: item.CategoryName);
            }

            WriteLine();
            WriteLine();
            WriteLine("Raw SQL query:\n");
            WriteLine(queryJoin.ToQueryString());
            WriteLine();
            WriteLine();
        }
    }

    static void GroupJoinCategoryProduct()
    {
        using Northwind db = new();
        var queryResults = db.Categories.AsEnumerable()
        .GroupJoin(
            inner:db.Products,
            innerKeySelector:c=>c.CategoryId,
            outerKeySelector:p=>p.CategoryId,
            resultSelector:(c,matchingProducts)=> new {
                c.CategoryName,
                products = matchingProducts.OrderBy(p => p.ProductName)
            }
        );

        foreach(var r in queryResults)
        {
            WriteLine($"\n\t{r.CategoryName}");
            foreach(var p in r.products)
                WriteLine(" {0} {1}",p.ProductName,p.ProductId);

        }
        
        
        // WriteLine("\n\nRaw SQL:\n{0}");

    }

    static void AggregateProducts()
    {
        using var db = new Northwind();
        if(db.Products.TryGetNonEnumeratedCount(out int countDbSet))
            WriteLine("Products count: {0}",countDbSet);
        else
            WriteLine("Count method not diposable inside DbSet<T> type");
        
        if(db.Products.ToList().TryGetNonEnumeratedCount(out int count))
            WriteLine("Products count: {0}",count);
        else

        WriteLine("Products list does not have a Count property.");
        WriteLine("{0,-25} {1,10}",
        arg0: "Product count:",
        arg1: db.Products.Count());

        WriteLine("{0,-27} {1,8}", // Note the different column widths.
        arg0: "Discontinued product count:",
        arg1: db.Products.Count(product => product.Discontinued));

        WriteLine("{0,-25} {1,10:$#,##0.00}",
        arg0: "Highest product price:",
        arg1: db.Products.Max(p => p.UnitPrice));

        WriteLine("{0,-25} {1,10:N0}",
        arg0: "Sum of units in stock:",
        arg1: db.Products.Sum(p => p.UnitsInStock));

        WriteLine("{0,-25} {1,10:N0}",
        arg0: "Sum of units on order:",
        arg1: db.Products.Sum(p => p.UnitsOnOrder));

        WriteLine("{0,-25} {1,10:$#,##0.00}",
        arg0: "Average unit price:",
        arg1: db.Products.Average(p => p.UnitPrice));
        
        WriteLine("{0,-25} {1,10:$#,##0.00}",
        arg0: "Value of units in stock:",
        arg1: db.Products.Sum(p => p.UnitPrice * p.UnitsInStock));

    }

    static void OutputTableOfProducts(Product[] products,int currentPage, int totalPages)
    {
        string line = new('-',count:73);
        string lineHalf = new('-',count:30);
        WriteLine(line);
        WriteLine("{0,4} {1,-40} {2,12} {3,-15}",
        "ID", "Product Name", "Unit Price", "Discontinued");
        WriteLine(line);
        foreach (Product p in products)
        {
        WriteLine("{0,4} {1,-40} {2,12:C} {3,-15}",
        p.ProductId, p.ProductName, p.UnitPrice, p.Discontinued);
        }
        WriteLine("{0} Page {1} of {2} {3}",
        lineHalf, currentPage + 1, totalPages + 1, lineHalf);
    }

    static void OutputPageOfProducts(IQueryable<Product> products,int pageSize, int currentPage, int totalPages)
    {
        // We must order data before skipping and taking to ensure
        // the data is not randomly sorted in each page.
        var pagingQuery = products.OrderBy(p => p.ProductId)
        .Skip(currentPage * pageSize).Take(pageSize);
        SectionTitle(pagingQuery.ToQueryString());
        OutputTableOfProducts(pagingQuery.ToArray(),currentPage, totalPages);
    }

    static void GetProductPages()
    {
        // using Northwind db = new();
        // int currentPage=0;
        // int pageSize = 10;
        // int totalPages = db.Products.Count()/pageSize;
        using Northwind db = new();
        int currentPage=0;
        int pageSize = 10;
        int totalPages = db.Products.Count()/pageSize;

        while(true)
        {
            Clear();
            // IQueryable<Product> productPage = db.Products
            // .OrderBy(p => p.ProductId)
            // .Skip(currentPage*pageSize)
            // .Take(pageSize);
            OutputPageOfProducts(db.Products,pageSize,currentPage,totalPages);
            
            Write("Press <- to page back, press -> to page forward, any key to exit.");
            
            ConsoleKey navKey = ReadKey().Key;
            //this easier to read
            if(navKey == ConsoleKey.LeftArrow)
            {
                if(currentPage==0)
                    currentPage=totalPages;
                else
                    currentPage--;
            }else if(navKey == ConsoleKey.RightArrow)
            {
                if(currentPage==totalPages)
                    currentPage=0;
                else
                    currentPage++;
            }else
                break;

            // if(navKey == ConsoleKey.LeftArrow && (currentPage==0))
            // {
            //         currentPage=totalPages;
            // }else if(navKey == ConsoleKey.LeftArrow)
            // {
            //     currentPage--;
            // }

            // if(navKey == ConsoleKey.RightArrow && (currentPage==totalPages))
            //     currentPage=0;
            // else if(navKey == ConsoleKey.RightArrow)
            //     currentPage++;
            

            //ReadLine();
        }
    }
    static void ProducstAsXML()
    {

        WriteLine("Output products as XML");
        using Northwind db = new();
        Product[] products = db.Products.ToArray();

        XElement xmlItem= new("Products", products
        .Select(p => new XElement("Product", 
        new XElement("Id",p.ProductId),
        new XElement("Price",p.UnitPrice),
        new XElement("Name",p.ProductName))));

        WriteLine(xmlItem.ToString());
    }

    static void ReadXMLWithLinQ()
    {
        string pathFile = Path.Combine(Environment.CurrentDirectory,"settings.xml");
        XDocument document = XDocument.Load(pathFile);
        
        var appsetting = document.Descendants("appSettings")
        .Descendants("add")
        .Select(node => new {
            key = node.Attribute("key")?.Value,
            value = node.Attribute("value")?.Value
        }).ToArray();

        foreach(var node in appsetting)
            WriteLine("key: {0} \nvalue: {1}\n",node.key,node.value);
    }
}