
using System.Xml;
using static System.Environment;
using static System.IO.Path;

partial class Program
{
    static void WritingToTextFile()
    {
        string filePath = Combine(CurrentDirectory,"stream.txt");
        WriteLine(filePath);
        StreamWriter sw = File.CreateText(filePath);

        foreach(string ob in Viper.callSigns)
        {
            sw.WriteLine(ob);
        }
        sw.Close();

        WriteLine("File {0} Cointains {1} bytes",
        arg0:filePath,
        arg1:new FileInfo(filePath).Length);
    }
    
    static void WritingToXMLfile()
    {
        string filePath = Combine(CurrentDirectory,"xmlfile.xml");

        FileStream? fs = null;
        XmlWriter? xmlW = null;

        try
        {
            fs = File.Create(filePath);
            xmlW = XmlWriter.Create(fs, new XmlWriterSettings{Indent=true});

            xmlW.WriteStartDocument();
            xmlW.WriteStartElement("callsigns");
            foreach(string ob in Viper.callSigns)
            {
                xmlW.WriteElementString("callsign",ob);
            }

            xmlW.WriteEndElement();
            xmlW.Close();
            fs.Close();
        }catch(Exception ex)
        {
            WriteLine($"{ex.GetType()} Says: {ex.Message}");
        }
        finally
        {
            if (xmlW != null)
            {
            xmlW.Dispose();
            WriteLine("The XML writer's unmanaged resources have been disposed.");
            }
            if (fs != null)
            {
            fs.Dispose();
            WriteLine("The file stream's unmanaged resources have been disposed.");
            }
        }

    }

    static void UsingUsingsInsteadOfTryFinally()
    {
        // using (FileStream FileStream = File.OpenWrite(Combine(CurrentDirectory,"xmlfile.xml")))
        // {
        //     WriteLine(Combine(CurrentDirectory,"xmlfile.xml"));
        //     using(StreamWriter streamWriter = new (FileStream))
        //     {
        //         try
        //         {
        //             streamWriter.WriteLine("Wellcome to .NET");
        //         }
        //         catch(Exception ex)
        //         {
        //             WriteLine($"{ex.GetType()} Says: {ex.Message}");
        //         }
        //     }
        // }


        //simplified
        using FileStream fileStream = File.OpenWrite(Combine(CurrentDirectory,"xmlfile.xml"));
        using StreamWriter streamWriter = new (fileStream); 

        try
        {
            streamWriter.WriteLine("Wellcome to .NET");
        }
        catch(Exception ex)
        {
            WriteLine($"{ex.GetType()} Says: {ex.Message}");
        }


    }

    static void Main()
    {
        // WritingToXMLfile();
        // WritingToTextFile();
        UsingUsingsInsteadOfTryFinally();
    }
}