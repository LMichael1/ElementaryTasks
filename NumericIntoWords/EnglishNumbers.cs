using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericIntoWords
{
    public class EnglishNumbers : INumberDictionary
    {
        public Dictionary<int, string> SmallNumbers { get; }
        public Dictionary<int, string> Tens { get; }
        public Dictionary<int, string> BigNumbers { get; }

        public string Minus { get; private set; }
        public string And { get; private set; }

        public EnglishNumbers()
        {
            SmallNumbers = new Dictionary<int, string>();
            FillSmallNumbers();

            Tens = new Dictionary<int, string>();
            FillTens();

            BigNumbers = new Dictionary<int, string>();
            FillBigNumbers();

            Minus = "minus";
            And = "and";
        }
        private void FillSmallNumbers()
        {
            SmallNumbers.Add(0, "zero");
            SmallNumbers.Add(1, "one");
            SmallNumbers.Add(2, "two");
            SmallNumbers.Add(3, "three");
            SmallNumbers.Add(4, "four");
            SmallNumbers.Add(5, "five");
            SmallNumbers.Add(6, "six");
            SmallNumbers.Add(7, "seven");
            SmallNumbers.Add(8, "eight");
            SmallNumbers.Add(9, "nine");
            SmallNumbers.Add(10, "ten");
            SmallNumbers.Add(11, "eleven");
            SmallNumbers.Add(12, "twelve");
            SmallNumbers.Add(13, "thirteen");
            SmallNumbers.Add(14, "fourteen");
            SmallNumbers.Add(15, "fifteen");
            SmallNumbers.Add(16, "sixteen");
            SmallNumbers.Add(17, "seventeen");
            SmallNumbers.Add(18, "eighteen");
            SmallNumbers.Add(19, "nineteen");
        }

        private void FillTens()
        {
            Tens.Add(2, "twenty");
            Tens.Add(3, "thirty");
            Tens.Add(4, "forty");
            Tens.Add(5, "fifty");
            Tens.Add(6, "sixty");
            Tens.Add(7, "seventy");
            Tens.Add(8, "eighty");
            Tens.Add(9, "ninety");
        }

        private void FillBigNumbers()
        {
            BigNumbers.Add(100, "hundred");
            BigNumbers.Add(1000, "thousand");
            BigNumbers.Add(1000000, "million");
            BigNumbers.Add(1000000000, "billion");
        }
    }
}
