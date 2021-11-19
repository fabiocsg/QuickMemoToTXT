using System;
using System.IO;

namespace QuickMemoToTXT
{
    class Program
    {
        private const string OutDirName = "Output";
        private const string CurrentDir = ".";

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("QuickMemo to TXT converter");
            
            var filesDir = args.Length > 0
                ? args[0]
                : CurrentDir;
            var outDir = Path.Combine(filesDir, OutDirName);

            try
            {
                Directory.CreateDirectory(outDir);
                new QuickMemoConverter(filesDir, outDir, Console.WriteLine).Run();
                Console.WriteLine();
                Console.WriteLine("DONE :>");
            } 
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Error while converting files :C");
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();            
        }
    }    
}
