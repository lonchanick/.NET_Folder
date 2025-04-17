
using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection



namespace Packt.Shared;

/*
 * Esto se llama extesion method y lo que hace es agregar una funcion o metodo al objeto IServiceCollection
 * de tal forma que cuando se haga referencia a esta libreria el metodo va a ser accesible desde cualquier
 * objeto IServiceCollection, en este caso este metodo va ser invocado desde el programa Northwind.Web
 * TODO ESTO ESTA DIPONIBLE EN PAG 548 LIBRO CHSHARP11 .NET7 - MARCK PRICE
 */
public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the
    //Sqlite database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="relativePath">Set to override the default of ".."
    //</param>
    /// <returns>An IServiceCollection that can be used to add more services.
    //</returns>
    public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string relativePath = "..")
    {
        /*
         * Sospecho yo que todo esto pudiese hacerse en el archivo program.cs del programa (Northwind.Web)
         * que este utilizando esta libreria
         */
        string databasePath = Path.Combine(relativePath, "Northwind.db");

        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlite($"Data Source={databasePath}");
            options.LogTo(WriteLine, // Console
            new[] { Microsoft.EntityFrameworkCore
            .Diagnostics.RelationalEventId.CommandExecuting });
        });

        return services;
    }
}
