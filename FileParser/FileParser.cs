using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class FileParser
    {
        private string _path;

        public FileParser(string path)
        {
            _path = path;
        }

        public int GetNumberOfSubstringEntries(string substring)
        {
            int result = 0;

            using (StreamReader reader = new StreamReader(_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    result += StringParser.GetNumberOfEntries(line, substring);
                }
            }

            return result;
        }

        public void ReplaceAllSubstringEntries(string oldValue, string newValue)
        {
            string tmpPath = Path.GetTempFileName();

            using (StreamReader reader = new StreamReader(_path))
            using (StreamWriter writer = new StreamWriter(tmpPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine(StringParser.ReplaceSubstring(line, oldValue, newValue));
                }
            }

            File.Delete(_path);
            File.Move(tmpPath, _path);
        }
    }
}
