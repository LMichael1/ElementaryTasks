using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericIntoWords
{
    interface INumberDictionary
    {
        Dictionary<int, string> SmallNumbers { get; }
        Dictionary<int, string> Tens { get; }
        Dictionary<int, string> BigNumbers { get; }
        string Minus { get; }
        string And { get; }
    }
}
