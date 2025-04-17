
public partial class Program
{
    static string[] names = ["Michael", "Pam", "Jim", "Dwight","Angela", "Kevin", "Toby", "Creed"];
    static List<Exception> exceptions = new()
    {
        new ArgumentException(),
        new SystemException(),
        new IndexOutOfRangeException(),
        new InvalidOperationException(),
        new NullReferenceException(),
        new InvalidCastException(),
        new OverflowException(),
        new DivideByZeroException(),
        new ApplicationException()
    };

static string[] cohort1 = new[] { "Rachel", "Gareth", "Jonathan", "George" };
static string[] cohort2 = new[] { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
static string[] cohort3 = new[] { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

static void Output(IEnumerable<string> cohort, string description="")
{
    if(!string.IsNullOrEmpty(description))
        WriteLine(description);

    WriteLine(string.Join(", ",cohort.ToArray()));

}


    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        ForegroundColor = previousColor;
    }

    //exaple to explain deferred execution.
    //Query: Names that ends with 'm'
    static void NamesEndedWithM()
    {
        //If I call toArray (or toList();) here, im executing the query; that is, to materialize the query
        var ExtensionMethodWay= names.Where(n => n.EndsWith('m'));
        var QueryComprenhensionWay = from name in names where name.EndsWith('m') select name;

        //there are two ways of materialize this query
        //first one
        string[]? stringWay = ExtensionMethodWay.ToArray();
        //second one
        List<string> listWay = QueryComprenhensionWay.ToList();


        foreach(var n in ExtensionMethodWay)
        {
            //esto lo que hace es ejecutar el query on-demand por asi decirlo
            WriteLine(n);
            //names[2]="Diegom";//esto si se imprimiria, 
            names[2]="Diego";
        }

    }

    static void FilteringByType<T>()
    {
        // WriteLine("\n\tList of exceptions: ");
        // foreach(Exception ex in exceptions)
        //     WriteLine(ex);
        WriteLine("\n\t\tFiltering by type");
        WriteLine($"\tPrinting Exceptions type: {typeof(T)}");
        IEnumerable<T> filter = exceptions.OfType<T>();
        
        foreach(T x in filter)
            WriteLine(x);

        WriteLine("\n");
        // ReadLine();
    }

    static void SetsAndBags()
    {
        WriteLine("\tWorking with sets and bags\n");
        Output(cohort1);
        Output(cohort2);
        Output(cohort3);
        WriteLine();
        SectionTitle("Set operations");
        Output(cohort2.Distinct(),"cohort2.Distinct()");
        Output(cohort2.DistinctBy(name => name.Substring(0, 2)),"cohort2.DistinctBy(name => name.Substring(0, 2)):");
        Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
        Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3)");
        Output(cohort2.Intersect(cohort3), "cohort2.Intersect(cohort3)");
        Output(cohort2.Except(cohort3), "cohort2.Except(cohort3)");
        Output(cohort1.Zip(cohort2,(c1, c2) => $"{c1} matched with {c2}"),"cohort1.Zip(cohort2)");


        WriteLine();
    }
}