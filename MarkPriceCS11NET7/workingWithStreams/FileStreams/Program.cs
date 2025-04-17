



using System;

using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace FileStreamsAndSerialization;

partial class Program
{
    static void Main()
    {
        #region PathDirectoryAndEnviroment
        // SectionTitle("* Handling cross-platform environments and filesystems");
        // WriteLine($"Path.PathSeparator: {Path.PathSeparator}");
        // WriteLine($"Path.DirectorySeparator: {Path.DirectorySeparatorChar}");
        // WriteLine($"CURRENT DIRECTORY: {Directory.GetCurrentDirectory()}");
        // WriteLine($"ENVIROMENT CURRENT DIRECTORY: {Environment.CurrentDirectory}");
        // WriteLine("ETC ...");
        // WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
       #endregion
       
       
       #region files
        // WriteLine();
        // WriteLine();

        // WriteLine("new folder name: ");
        // string folderName = ReadLine();
        // string r = Combine(GetFolderPath(SpecialFolder.Personal), folderName);
        // WriteLine("Working with: "+r);
        // WriteLine("Exist \"{0}\" -> {1}",r, Path.Exists(r));
        // if(Path.Exists(r))
        // {
        //     WriteLine("Folder already exist, press ENTER to continue");
        //     ReadLine();

        // }else
        // {
        //     //create directory
        //     WriteLine("Creating directory");
        //     Directory.CreateDirectory(r);
        //     WriteLine("Exist \"{0}\" -> {1}",r, Path.Exists(r));
        //     Write("Confirm the directory exists, and then press ENTER: ");
        //     ReadLine();
        // }

        
        // WriteLine();
        // string documentsFolder = GetFolderPath(SpecialFolder.Personal);
        // string WorkingDirectory = Combine(documentsFolder,"WorkingDirectory");
        // WriteLine("Path: {0}",WorkingDirectory);
        // WriteLine("Exist {0}", File.Exists(WorkingDirectory));
        // Directory.CreateDirectory(WorkingDirectory);
        // WriteLine("Working directory created");
        // Write("Enter to continue..");
        // ReadLine();
        // WriteLine();
        // WriteLine();
        // Write("Enter the new file name: ");
        // string newFileName = ReadLine();
        // string newFileDirectory = Combine(WorkingDirectory,newFileName);
        // StreamWriter sw = File.CreateText(newFileDirectory);
        // sw.WriteLine("Hola mundo desde adentro");
        // sw.Close();
        // WriteLine("New file created an writen");
        // // var fs = File.Open(pathAndName, FileMode.Open);
        // // File.WriteAllText(pathAndName,"Hello from inside the file");

        // WriteLine();
        // WriteLine();
        // WriteLine("Creating backup folder");
        // Write("Enter to continue..");
        // ReadLine();
        // WriteLine();
        // WriteLine("Enter the backup folder name: ");
        // string backupFolerName = ReadLine();
        // string backupFolderDirectory = Path.Combine(WorkingDirectory,backupFolerName);
        // Directory.CreateDirectory(backupFolderDirectory);
        // WriteLine("Done! Folder created.");
        // WriteLine("Backing up: {0} \nin: {1}...", newFileDirectory, backupFolderDirectory);
        // backupFolderDirectory+=".txt";
        // File.Copy(sourceFileName:newFileDirectory , destFileName: backupFolderDirectory, overwrite:true);
        // WriteLine();
        // WriteLine();
        // WriteLine();
        // ReadLine();
        #endregion

        ManagingPaths();


    }

}