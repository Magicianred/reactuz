using Ionic.Zip;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace samandar_react
{
    class Program
    {
        private static string projectPath;
        private static string templateName;
        private static string notFoundMsg = "Parametrlarni to'gri kiring. Masalan, 'samandar projectname'";
        static void Main(string[] args)
        {
            Console.Clear();
            templateName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Genius Coders\React-GC\react-gc");
            Console.Title = templateName;
            //
            //Environment.SetEnvironmentVariable("Path", projectPath);
            //
            if (args.Length == 1)
            {
                projectPath = Path.Combine(Environment.CurrentDirectory, args[0]);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Papkalar yaratilyapti...");
                Console.ForegroundColor = ConsoleColor.Green;
                // Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(templateName, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(templateName, projectPath));

                //Copy all the files & Replaces any files with the same name
                var files = Directory.GetFiles(templateName, "*.*", SearchOption.AllDirectories);
                long currentFilesCount = 0, filesCount = files.Length;
                foreach (string newPath in files)
                {
                    File.Copy(newPath, newPath.Replace(templateName, projectPath), true);
                    currentFilesCount++;
                    Console.Title = "Hozirgi jarayon: " + (currentFilesCount * 100 / filesCount).ToString() + "%";
                    Console.WriteLine("GeniusCoders@~" + newPath);
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(notFoundMsg);
                Console.ResetColor();
            }
        }

    }
}
