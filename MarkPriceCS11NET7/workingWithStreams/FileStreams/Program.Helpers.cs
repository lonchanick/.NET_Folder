
namespace FileStreamsAndSerialization;

partial class Program
{
    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Green;
        WriteLine("*");
        // WriteLine($"{title}");
        WriteLine(title);
        WriteLine("*");
        ForegroundColor = previousColor;
    }

    static void ManagingPaths()
    {
        string pathFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"WorkingDirectory","sample.txt");
        WriteLine(pathFile);
        WriteLine("Folder Name: {0}",Path.GetDirectoryName(pathFile));
        WriteLine("File Name: {0}",Path.GetFileName(pathFile));
        WriteLine("File Name without extension: {0}",Path.GetFileNameWithoutExtension(pathFile));
        WriteLine("File Extension: {0}",Path.GetExtension(pathFile));
        WriteLine("Ramdom File Name: {0}",Path.GetRandomFileName());
        WriteLine("Temporary File Name: {0}",Path.GetTempFileName());



        WriteLine();
        WriteLine();
        WriteLine();

        WriteLine("File info");
        FileInfo fi = new(pathFile);
        WriteLine("File: {0}", fi);
        WriteLine("File lenght bytes: {0}", fi.Length);
        WriteLine("File last acces time: {0}", fi.LastAccessTime);
        WriteLine("File Is Read only: {0}", fi.IsReadOnly);

        FileInfo info = new(pathFile);
        WriteLine("Is the backup file compressed? {0}",
        info.Attributes.HasFlag(FileAttributes.Compressed));


    }


}