
// namespace whiteBoard;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;


Exe();



#region RandomNumbers
//random numbers
// void Exe()
// {
//     Random random = Random.Shared;
//     for(int i=0; i<10 ;i++)
//         Write(random.Next(minValue:1, maxValue:11)+", ");

//     byte[] arrayOfBytes = new byte[50];
//     random.NextBytes(arrayOfBytes);
//     for(int i=0; i<50; i++)
//         WriteLine(i+") "+arrayOfBytes[i]);
// }
#endregion


#region StringType
//string type in C#
// void Exe()
// {
//     string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";
//     var result = cities.Split(",");
//     WriteLine(result.GetType());
//     foreach(var x in result)
//         WriteLine(x);
// }


// void Exe()//Getting part of a string
// {
//     string cities = "Shore, Alan";
//     int index = cities.IndexOf(',');
//     string firstName = cities.Substring(startIndex:0, index);
//     string secondName = cities.Substring(index+=2);

//     WriteLine("{0} {1}", firstName, secondName);
//     WriteLine("{0} {1}", secondName,firstName );

//     WriteLine("========================\n\tStringBuilders");
//     string[] aux = "Paris,Tehran,Chennai,Sydney,New York,Medellín".Split(',');
//     foreach(var x in aux)
//         WriteLine(x);

//     StringBuilder sb=new();
//     foreach(string x in aux)
//     {
//         sb.Append(x);
//     }

//     WriteLine(sb);

// }

#endregion


#region RegularExpressions

// void Exe()
// {
//     // string input = ReadLine()!;
//     // Regex ageCheked = new(@"^\d+$");
//     // WriteLine(ageCheked.IsMatch(input));

//     string films = """"Monsters, Inc.","I, Tonya","Lock, Stock and Two Smoking Barrels"""";
//     WriteLine($"Films to split: {films}");
//     string[] filmsDumb = films.Split(',');
//     WriteLine("Splitting with string.Split method:");
//     foreach (string film in filmsDumb)
//     {
//     WriteLine(film);
//     }
// }

#endregion


#region ImprovingPerformanceEnsuringCapacity

// void Exe()
// {
//     List<string> list = new();
//     list.EnsureCapacity(4);

//     for(int i=0; i<100; i++)
//         list.Add("Hola");

//     foreach(string x in list)
//         WriteLine(x);

// }


#endregion


#region WorkingWithList
// void Exe()
// {
//     void PrintList(List<string> listOfString)
//     {
//         int cont=0;
//         foreach(var x in listOfString)
//             WriteLine($"{cont++}-{x}");
    
//         WriteLine();
//     }

//     List<string> listOfString = new();
//     listOfString.AddRange(new string[]{"hola","Mundo","Como","Estas"});
//     listOfString.Insert(0,"In the begining");
    
//     PrintList(listOfString);

//     listOfString.Remove("Mundo");
//     WriteLine(""">> listOfString.Remove("Mundo");""");
//     PrintList(listOfString);

//     listOfString.RemoveAt(2);
//     WriteLine(""">> listOfString.RemoveAt(2);""");
//     PrintList(listOfString);

// }

#endregion


#region WorkingWithDictionaries

// void Exe()
// {
//     void PrintList(Dictionary<string,string> words)
//     {
//         int cont=0;
//         foreach(KeyValuePair<string,string> x in words)
//             WriteLine($"{cont++}-{x.Key} - {x.Value}");
    
//         WriteLine();
//     }

//     Dictionary<string, string> words = new()
//     {
//         ["Conturbado"]="Lookup for definition",
//         ["Resiliente"]="More content",
//         ["Get"]="Lorem ipsums",
//     };

//     WriteLine($"Keys: {words.Keys}");
//     WriteLine($"Values: {words.Values}");

//     PrintList(words);

// }

#endregion


#region WorkingWithQueue

//pendiente

#endregion


#region indexType

// void printArr(string [] arr)
// {
//     foreach(string val in arr)
//         WriteLine(val);
// }

// void Exe()
// {
//     // string [] arr = {"Uno","Dos","Tres","Cuatro","Cinco"};
//     // string [] result = arr[0..2];
//     // printArr(result);

//     string name = "Samantha Jones";
//     // getting the lengths of the first and last names
//     int lengthOfFirst = name.IndexOf(' ');
//     int lengthOfLast = name.Length - lengthOfFirst-1;

//     WriteLine($"Size Of first: {lengthOfFirst}");
//     WriteLine($"Size of last: {lengthOfLast}");

//     string first = name[0..name.IndexOf(' ')];
//     string last=name[(name.IndexOf(' ')+1)..];
//     WriteLine(first);
//     // Write('=');
//     WriteLine(last);
// }


#endregion



#region networkResources

// void Exe()
// {
    // Write("Enter a valid web address (or press Enter): ");
    // string url = ReadLine();

    // if(string.IsNullOrEmpty(url))
    //     url="https://stackoverflow.com/search?q=securestring";

    // Uri uri = new(url);
    // WriteLine($"URL: {url}");
    // WriteLine($"Scheme: {uri.Scheme}");
    // WriteLine($"Port: {uri.Port}");
    // WriteLine($"Host: {uri.Host}");
    // WriteLine($"Path: {uri.AbsolutePath}");
    // WriteLine($"Query: {uri.Query}");
    
    // IPHostEntry entry = Dns.GetHostEntry(uri.Host);
    // WriteLine($"{entry.HostName} has the following IP addresses:");
    
    // foreach (IPAddress address in entry.AddressList)
    // {
    // WriteLine($" {address} ({address.AddressFamily})");
    // }


    // try
    // {
    // Ping ping = new();
    // WriteLine("Pinging server. Please wait...");
    // PingReply reply = ping.Send(uri.Host);
    // WriteLine($"{uri.Host} was pinged and replied: {reply.Status}.");
    // if (reply.Status == IPStatus.Success)
    // {
    // WriteLine("Reply from {0} took {1:N0}ms",
    // arg0: reply.Address,
    // arg1: reply.RoundtripTime);
    // }
    // }
    // catch (Exception ex)
    // {
    // WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
    // }

// }
    
#endregion

#region Chap#9_FilesStreamsSerialization
static void SectionTitle(string title)
{
    ConsoleColor previousColor = ForegroundColor;
    ForegroundColor = ConsoleColor.Yellow;
    WriteLine("*");
    WriteLine($"* {title}");
    WriteLine("*");
    ForegroundColor = previousColor;
}

void Exe()
{
    // SectionTitle("Handling Cross-platform enviroments and filesystems");
    // WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator",arg1: PathSeparator);
    // WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar",arg1: DirectorySeparatorChar);
    // WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",arg1: GetCurrentDirectory());
    // WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",arg1: CurrentDirectory);
    // WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",arg1: SystemDirectory);
    // WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",arg1: GetTempPath());
    // WriteLine("GetFolderPath(SpecialFolder");
    // WriteLine("{0,-33} {1}", arg0: " .System)", arg1: GetFolderPath(SpecialFolder.System));
    // WriteLine("{0,-33} {1}", arg0: " .ApplicationData)",arg1: GetFolderPath(SpecialFolder.ApplicationData));
    // WriteLine("{0,-33} {1}", arg0: " .MyDocuments)",arg1: GetFolderPath(SpecialFolder.MyDocuments));
    // WriteLine("{0,-33} {1}", arg0: " .Personal)",arg1: GetFolderPath(SpecialFolder.Personal));

    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}","NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        if (drive.IsReady)
        {
            WriteLine(
            "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
            drive.Name, drive.DriveType, drive.DriveFormat,
            drive.TotalSize, drive.AvailableFreeSpace);
        }
        else
        {
            WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
        }
    }
}

#endregion

