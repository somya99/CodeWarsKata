using System;
using System.IO;
namespace readdirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\C#Files";

            Console.WriteLine(Directory.GetDirectoryRoot(filename));
            Console.WriteLine(Directory.GetLastAccessTimeUtc(filename));
            //Console.WriteLine(Directory.Exists(filename));
            Console.WriteLine(Directory.GetFiles(filename));
        }
    }
}
