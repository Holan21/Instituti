using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    internal class Program
    {
        public static string pathLogs = "logs";
        public static ConsoleColor deafultColor = Console.ForegroundColor;
        static async Task Main(string[] args)
        {
            try
            {
                if (!Directory.Exists(pathLogs)) Directory.CreateDirectory(pathLogs);
                Thread th = new Thread(new ThreadStart(RemoverLogs));

                Thread.CurrentThread.Name = "Main";
                th.Name = "Service#1";

                Task task = Task.Factory.StartNew(() => WriteLog(pathLogs, "Hello world\nError not Found(Error 404)"));
                task.Wait();
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("--------------Start read Logs--------------");
                Console.WriteLine(await ReadLogs(pathLogs));
                Console.WriteLine("--------------End read Logs--------------");
                Console.ForegroundColor = deafultColor;

                th.Start();

                while (true) ;
            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }
            //logic wait new task for create logs
        }

        private static void RemoverLogs()
        {
            string logsPaths = pathLogs;
            if (string.IsNullOrEmpty(logsPaths)) throw new Exception("Directory is null");

            while (true)
            {
                try
                {
                    var files = new DirectoryInfo(logsPaths).GetFiles($"*.log");
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (DateTime.Now.AddMinutes(-1) >= files[i].CreationTime)
                        {
                            files[i].Delete();
                            Console.WriteLine($"[{Thread.CurrentThread.Name}] File was delete");
                        }
                    }

                }
                catch (Exception ex)
                {
                    WriteError(ex.Message);
                }
            }
        }

        private static void WriteLog(string logsPath , string log)
        {
            if (string.IsNullOrEmpty(logsPath)) throw new Exception("Logs path is not valid");
            string fileName = $"{logsPath}/{DateTime.Now}.log".Replace(" " , "_").Replace(":" , ".");
            File.Create(fileName).Close();
            File.WriteAllText(fileName, log);
        }

        private static async Task<string> ReadLogs(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) throw new FileNotFoundException("File don't exists");
            string result = string.Empty;
            var files = new DirectoryInfo(directoryPath).GetFiles();
            for(int i =0; i < files.Length; i++)
            {
               result += '\n'+ files[i].Name + '\n';
               result +='\n' +  File.ReadAllText(files[i].FullName) + '\n';
            }
            
            return result;
        }

        private static void WriteError(string error)
        {
            Console.WriteLine($"[{Thread.CurrentThread.Name}]{error}");
        }
    }
}
