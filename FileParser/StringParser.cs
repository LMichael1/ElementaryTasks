using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class StringParser
    {
        public static int GetNumberOfEntries(string line, string pattern)
        {
            return line.Split(new string[] { pattern }, StringSplitOptions.None).Length - 1;
        }

        public static string ReplaceSubstring(string line, string oldValue, string newValue)
        {
            if (line.Contains(oldValue))
            {
                line = line.Replace(oldValue, newValue);
            }

            return line;
        }
    }
}
