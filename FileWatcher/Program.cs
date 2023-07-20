using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;




namespace Mycode
{
    class MyFiles
    {
        static void Main(string[] args)
        {
           string path =  ConfigurationManager.AppSettings.Get("Key0");
            var watcher = new FileSystemWatcher(path);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
            updatelog($"Changed: {e.FullPath}");
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath} date : {DateTime.Now.ToString("dddd, dd MMMM yyyy hh: mm tt")}";
            Console.WriteLine(value);
            updatelog(value);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Deleted: {e.FullPath}");
            updatelog($"Deleted: {e.FullPath}");
        }

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Renamed:");
            Console.WriteLine($"    Old: {e.OldFullPath}");
            Console.WriteLine($"    New: {e.FullPath}");
            updatelog($"Renamed:");
            updatelog($"    Old: {e.OldFullPath}");
            updatelog($"    New: {e.FullPath}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
        public static void updatelog(string msg)
        {
            string logpath2 = "D:\\Log\\";
            string pathName = logpath2+"Log- "+DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (File.Exists(pathName))
            {
                File.AppendAllText(pathName, msg + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(pathName, msg + Environment.NewLine);
            }
        }


    }
}
