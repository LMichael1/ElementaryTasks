using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileParser parser = new FileParser(@"D:\test.txt");
            Console.WriteLine(parser.GetNumberOfSubstringEntries("abab"));
            Console.ReadKey();
        }
    }
}
