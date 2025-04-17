
using System.Xml.Serialization;
using static System.IO.Path;
using static System.Environment;
using FasterLibrary = System.Text.Json.JsonSerializer;

partial class Program
{
    public static List<Person> people = new()
    {
        new(30000M)
        {
            FirstName="Diego",
            Lastname="Arroyo",
            DateOfBirth=new(1991,08,10)
        },
        new(40000M)
        {
            FirstName="Agustin",
            Lastname="Arroyo",
            DateOfBirth=new(2022,06,06)
        },
        new(50000M)
        {
            FirstName="Carlos",
            Lastname="Arroyo",
            DateOfBirth=new(1965,03,17),
            Chindren = new()
            {
                new(0M)
                {
                    FirstName="Karla",
                    Lastname="Arroyo",
                    DateOfBirth=new(2006,06,16)
                }
            }
        }
    };
    static void XmlSerializing()
    {
        XmlSerializer xmlSer = new(type: people.GetType());
        string path = Combine(CurrentDirectory,"xmlSerialized.xml");

        using (FileStream fs = File.Create(path))
        {
            xmlSer.Serialize(fs, people);
        }

        Console.WriteLine(File.ReadAllText(path));
        WriteLine();
        Console.WriteLine("Path: {0}\nFile Size: {1}", path, new FileInfo(path).Length);
        Console.WriteLine();
        // Person.PrintList(people);

        WriteLine("\tDESERIALIZING");
        using(FileStream fs = (File.Open(path, FileMode.Open)))
        {
            List<Person>? peopleLoaded = xmlSer.Deserialize(fs) as List<Person>;
            WriteLine("People Loaded:\n");
            Person.PrintList(peopleLoaded);
        }

        Person p = new(){FirstName="Hola"};

    }

    static void JsonSerializing()
    {
        string pathFile = Combine(CurrentDirectory,"jsonSerializedFile.json");
        using(StreamWriter steamWriter = File.CreateText(pathFile))
        {
            Newtonsoft.Json.JsonSerializer js = new();
            js.Formatting = Newtonsoft.Json.Formatting.Indented;
            js.Serialize(steamWriter,people);
        }

        WriteLine("File Name: {0}\nFile Size: {1}",
        arg0:Path.GetFileName(pathFile),
        arg1:new FileInfo(pathFile).Length);
    }
    static async void JsonSerializingSystemTextJsonSerializingFasterLibrary()
    {
        string pathFile = Combine(CurrentDirectory,"jsonSerializedFile.json");
        using(FileStream fs = File.Open(pathFile, FileMode.Open))
        {
            List<Person>? loadedPeople = await FasterLibrary.DeserializeAsync
            (utf8Json: fs, returnType: typeof(List<Person>)) as List<Person>;

            Person.PrintList(loadedPeople);
        }
    }
}