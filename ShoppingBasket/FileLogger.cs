using System;
using System.IO;
using System.Reflection;

namespace ShoppingBasket
{
    public class FileLogger : ILogger<Summary>
    {
        public string Path { get; }
        public string FullPath { get; }
        public FileLogger()
        {
            var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
            var removeIdx = Directory.GetCurrentDirectory().LastIndexOf(assemblyName);
            Path = Directory.GetCurrentDirectory().Remove(removeIdx);
            FullPath = $"{Path}/{assemblyName}/Discounts.txt";
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        
        public void Log(Summary details)
        {
            if (File.Exists(FullPath))
            {
                File.AppendAllText(FullPath, $"----{DateTime.Now.ToString()}-----\n\n");
            }
            else
            {
                File.WriteAllText(FullPath, $"----{DateTime.Now.ToString()}-----\n\n");
            }

            File.AppendAllText(FullPath, details.ToString());
        }
    }
}