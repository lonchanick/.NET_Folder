/*using SubjectsByNameSpace.SetAndGetMethods;

var x = new ClassForTest();
x.privateField = "12345678-1";
//x.privateField = null;
*/

/*string aux = new('_', count: 74);
Console.WriteLine(aux);*/

//Console.WriteLine("\television/Name");
//Console.WriteLine(@"\television/Name");

//funciona desde CSharp 11 en adelante
//string aux = """
//     <PropertyGroup>
//      <OutputType>Exe</OutputType>
//      <TargetFramework>net6.0</TargetFramework>
//      <ImplicitUsings>enable</ImplicitUsings>
//      <Nullable>enable</Nullable>
//    </PropertyGroup>
//    """;


//formating float numbers
//float f = 1.123123f;
//Console.WriteLine("{0:N4}{1}",f," Float type");

//int integer = 10;
//int binary = 0b_1010;
//Console.WriteLine($"{integer} |==?| {binary} =>{integer==binary}");

/*
using SubjectsByNameSpace.SetAndGetMethods;
//target-formated new
List<ClassForTest> list = new()
{
    new() { privateField = "1234567890"},
    new() { privateField = "1234567890" },
    new() { privateField = "1234567890" },
    new() { privateField = "1234567890-x" },
};*/

//Console.WriteLine("String default value: {0}", default(string));
//Console.WriteLine("Int default value: {0}", default(int));
//Console.WriteLine("Float default value: {0}", default(float));
//Console.WriteLine("Double default value: {0}", default(double));
//Console.WriteLine("DateTime default value: {0}", default(DateTime));

/*decimal price = 10.22M;
int numbersOf = 10;
Console.WriteLine($"{price*numbersOf:C}");*/

//currency
/*decimal price = 10.22M;
Console.WriteLine($"{price:C}");*/

/*
//string format
string apple = "apple";
int quantity = 1012312312;

Console.WriteLine("{0,-10}{1,-6}{2,6}", "Friut","<>","Count");
Console.WriteLine("1234567890------******");
//Console.WriteLine("{0,-10}{1,6:N0}", apple, quantity);*/

//using static System.Console;//importa un metodo estatico, si omitimos la palabra static estariamos
//tratando de importar un namespace
/*string aux;
aux = ReadLine()!;
WriteLine(aux);*/

//Geting key inpúts from the user
/*Write("Press any key convination\n");
ConsoleKeyInfo x = ReadKey();
WriteLine("\nKey: {0} Modifiers: {1}  keyChar: {2}",x.Key,x.Modifiers,x.KeyChar);*/

//asyng and await
/*HttpClient httpClient = new();
HttpResponseMessage response = await httpClient.GetAsync("https://www.google.com");
WriteLine("Google has {0:N0} bytes",response.Content.Headers.ContentLength);*/

//Subject: Raw string literal
//https://stackoverflow.com/questions/75256018/c-sharp-triple-double-quotes-three-double-quotes
//we have got to change the C# version in our .csproj file (double-click on project (beneath solution)
//WriteLine(""" This \nis \tfor scape "this" without no issue """);


//practicing part page 96
//1.- show compiler and language version
//WriteLine(Environment.Version);
//framework version but CSharp version?
//2.- two types of comments // and /**/
//3.- differences between verbatim and interpolated
//var @var = "hola mundo";
//WriteLine(@var);

//4.-Careful when you use float and double values
//WriteLine("\n");
//WriteLine(@"//4 Careful when you use float and double values");
//double d1 = 0.1;
//double d2 = 0.2;
//WriteLine(@"double d1 = 0.1;
//double d2 = 0.2;");
//WriteLine(@"WriteLine(d1 + d2 == 0.3);");
//WriteLine(d1 + d2 == 0.3);
//decimal dc1 = 0.1M;
//decimal dc2 = 0.2M;
//WriteLine(@"decimal dc1 = 0.1M;
//decimal dc2 = 0.2M;
//WriteLine(dc1 + dc2 == 0.3M);");
//WriteLine(dc1 + dc2 == 0.3M);
//WriteLine("\n");

////5.- determinig size of types
//WriteLine("Decimal format size: {0}", sizeof(decimal));
//WriteLine(@"//5 determinig size of types
//WriteLine(""Decimal variable type size: {0}"", sizeof(decimal));");

////6.- How do you right-align a format string?
//WriteLine("\n");
//WriteLine(@"//6.- How do you right-align a format string?
//WriteLine(""{0,-9}{1,9}"",Environment.CurrentDirectory,Environment.Version);");
//WriteLine("{0,-9}{1,9}", "Hello","World");
//WriteLine("12345...91...56789");
////Console.WriteLine("{0,-10}{1,-6}{2,6}", "Friut", "<>", "Count");

/*
 * to see charp version, just hover pointer over the expression
#error version
*/

//extra bonus excercice
/*using static SubjectsByNameSpace.sizeOfVariableTypes.exe;
VariableTypeSize();*/

/*using CSharp_11_Book;
SwitchAndClasses.exe();*/

//foreach comprehensive
/*using System.Collections;

int[] list = { 8,6,32,47,265 };
IEnumerator e = list.GetEnumerator();
while(e.MoveNext())
{
    WriteLine($"Number: {e.Current}");
}*/


//using SubjectsByNameSpace.Arrays;
//Arrays.PatternMatching();
//Arrays.BidimencionalArray();
//Arrays.jaggedArray();

//long x=1231312312312;
//WriteLine($"{x.GetType()} | {x.ToString().GetType()}");



//byte array
//using System;
//byte[] arr = new byte[128];
//Random.Shared.NextBytes(arr);

//for(int f=0; f<arr.Length; f++)
//{
//    Write($"{Convert.ToString(arr[f],2)} => {arr[f]}"+"\n");
//}

//using SubjectsByNameSpace.TryCatch;
//tryCatch.exe();

//WriteLine(Byte.MaxValue);





/*DoSomething(7, "Parametro es lo que se espesifica en la funcion");
DoSomething(namedString:"Y argumento es lo que se le pasa a la funcion");

void DoSomething(int n=0, string namedString ="default")
{
    WriteLine(n + " "+ namedString);
}*/


/*using CSharp_11_Book;
//XML comments
SwitchAndClasses.exe();*/

//lambda => imperative and funtional
//diferences between:
//  imperative and declarative -> function implementation!!!


//WriteLine(doSomething(1));

/*WriteLine("beggining");

float r = 2.2f + 2.22f;

r = --r;
WriteLine(r);
WriteLine("middle point");



WriteLine("end point");
var r2 = r / 2;
WriteLine("<>");
WriteLine("<>");
WriteLine("<>");

Lorem();

WriteLine("<>");
WriteLine("<>");
WriteLine("<>");

WriteLine("end point");


void Lorem()
{
    for (int i = 0; i < 10; i++)
    {
        WriteLine("Hola {0}", i);
    }
}*/


/*
    LOGGS 
 */

/*using System.Diagnostics;

Debug.WriteLine("Hola primer mensaje");
Trace.WriteLine("Hola Segundo mensaje");

string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "log.txt");
//Debug.WriteLine(path);
TextWriterTraceListener log = new(File.CreateText(path));
Trace.Listeners.Add(log);

Trace.AutoFlush = true;
Trace.WriteLine("Hola");
Trace.WriteLine("vengo del log!");*/
/*
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

WriteLine("Reading from appsettings.json {0}",Directory.GetCurrentDirectory());

ConfigurationBuilder builder = new();

builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json",optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new TraceSwitch(
    displayName: "PacktSwitch",
    description: "This switch is set via a JSON config.");

configuration.GetSection("PacktSwitch").Bind(ts);

Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace Warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace Info");
//Trace.WriteLineIf(ts.TraceVerbose, "Trace Verbose");

Console.ReadLine();*/

/*var x = Environment.SpecialFolder.DesktopDirectory;
var r = Environment.GetFolderPath(x);
WriteLine(r);*/





/*using CalculatorLib;
using System.Threading;
*/
//try { fun1(); }
//catch (Exception ex)
//{
//    WriteLine(ex.Message);
//}
/*
fun1();
WriteLine("Hola mundo");

void withDraw(string accountName, double amount)
{
    *//*if(accountName is null)
    {
        throw new Exception(message:"Error gilipolla");
    }*//*
    ArgumentNullException.ThrowIfNull(accountName);

}

void fun1()
{
    fun2();
}
void fun2()
{
    try 
    { 
        Calculator.divideByZero(1);
    }catch
    {
        throw; //this include more info
        //throw new Exception(); //this trim the info that come from the exception generated at divideByZero(1) function
    }
}*/




//using CSharp_11_Book;

//EnumsMultipleValues.exe();


/*
(string hola, int mundo) friut = getFriut();

WriteLine("Tuple content: item1: {0} item2: {1}", friut.hola, friut.mundo);

(string hola, int mundo) = getFriut();

WriteLine("Tuple content: hola: {0} mundo: {1}", hola, mundo);


WriteLine("\n\tDeconstructing tuple value");
(string stringDeconstructed, int intDeconstructed) = friut;
WriteLine("First value deconstructed: {0}\nSecond Value deconstructed: {1}", stringDeconstructed, intDeconstructed);

WriteLine("\n\tDeconstructing objecs into tuples");
//(string papa, string mama) = new Person();
var bob = new Person { hermano1="Pepe"*//*, hermano2="Clavo"*//*};
var (papa, mama) = bob;

WriteLine("{0} <> {1}",papa, mama);

var (papax, mamax, numDeHermanos) = bob;

WriteLine("Papa: {0} <> Mama: {1} <> Num de hermanos: {2}", papax, mamax, numDeHermanos);

(string, int) getFriut()
{
    return ("Apples", 20);
}

public class Person
{
    public string papa { get; set; } = "Default-pa";
    public string mama { get; set; } = "Default-ma";
    public string hermano1 { get; set; } = "none";
    public string hermano2 { get; set; } = "none";

    public int numeroDeHermanos {
        get {
            int count = 0;
            if (!hermano1.Equals("none"))
                count++;
            if (!hermano2.Equals("none"))
                count++;

            return count;
        }
        //set { } 
    }

    public void Deconstruct(out string? papa, out string? mama)
    {
        papa = this.papa;
        mama = this.mama;
    }
    public void Deconstruct(out string? papa, out string? mama, out int numDeHermanos)
    {
        papa = this.papa;
        mama = this.mama;
        numDeHermanos = this.numeroDeHermanos;
    }

}*/



/*
using CSharp_11_Book;
var x = new BookSerie();*/

/*foreach(var colection in x.Books )
{
    WriteLine(colection.Key);
    WriteLine(colection.Value.ToString("\t"));
}*/

/*WriteLine(x);
WriteLine("Todoe n orde");
return;*/

/*for(int f=0; f<x.count();f++)
{
    WriteLine(x[f]);
}*/

//WriteLine(x[0].ToString("\t"));
//var f = x["Second Collection"][0];
//WriteLine(f);



///<subject>
///Unit testing
///page 183
///book CSharp 11 and .NET 7
/// </subject>
/// 
///<subject>
///Exceptions
///page 193
///book CSharp 11 and .NET 7
/// </subject>
/// 
///<subject>
///Chapter 5 POO : Creating ut own objects
///page 200
///book CSharp 11 and .NET 7
/// </subject>
/// 
///<subject>
///Chapter 5 POO : ENUMS multiple values
///page 212
///book CSharp 11 and .NET 7
/// </subject>
/// <seealso cref="https://www.youtube.com/watch?v=Pp7T-O3dIrs&ab_channel=CodingTutorials"/>
/// 
///<subject>
///Chapter # POO : Tuples
///page 220
/// </subject>
/// 
///<summary>
///Indexers y Extension methods
/// </summary>
///<summary>
///Implementing functionality
/// </summary>
/// 

/*
using PacktLibraryNetStandard2;

Person Diego = new()
{
    name = "Diego",
    city = "Guayaquil",
    BirthDay = new DateTime(1996,08,10)
};

Person Dayana = new()
{
    name = "Dayana",
    BirthDay = new DateTime(1990, 10, 08)
};

Person.Marry(Diego, Dayana);
Person.Procreate(Diego, Dayana);
Person.Procreate(Diego, Dayana);
Person.Procreate(Diego, Dayana);

WriteLine(Diego);WriteLine("\n");
WriteLine(Dayana);*/

using PacktLibraryNetStandard2;
//lamech history
/*Person lamech = new Person { name = "Lamech" };
Person Adah= new Person { name = "Adah" };
Person Zillah = new Person { name = "Zillah" };*/

//lamech.Marry(Adah);
/*if (lamech + Adah)
    WriteLine("Just married {0} and {1}", lamech.name, Adah.name);

Person.Marry(Zillah, lamech);

var r = Zillah * lamech;
var r2 = lamech * Adah;

WriteLine(lamech);
WriteLine(Zillah);
WriteLine(Adah);*/



//recursivity

/*WriteLine(factorial(5));

int factorial(int num)
{
    if (num == 0) return 1;
    return num * factorial(num-1);
}
*/


//*******************************************
//TEMA: Pattern Matching with objects pag:242
//*******************************************
/*
Passenger[] passengers = {
    new FirstClassPassenger { Name = "First Class#1", AirMiles=1_777_133 },
    new FirstClassPassenger { Name = "First Class#2", AirMiles=1_777_132 },
    new BuisinessClassPassenger { Name = "Buisiness Class#1",  },
    new CoachClassPassenger {Name="Amit", CarryOnKG=20.25},
    new CoachClassPassenger {Name="Dave", CarryOnKG=0}
};

foreach(var passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        *//*FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger _                         => 2000M,*//*
        FirstClassPassenger p => p.AirMiles switch
        {
            >35000 => 1500M,
            >15000 => 1750M,
            _      => 2000M
        },
        BuisinessClassPassenger _                     => 1000M,
        CoachClassPassenger p when p.CarryOnKG<10.0   => 500M,
        CoachClassPassenger _                         => 650M,
        _                                             => 800M
    };
    WriteLine($"FlightCost: {flightCost:C} for passenger {passenger}");
}

*/

//propiedades que se inicializan y ya no se pueden modificar
/*ImmutablePerson Jeff = new()
{
    FirstName = "Jeff",
    LastName = "Bezos"
};*/

//Jeff.FirstName = "Modifiing"; //error


