using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericIntoWords
{
    class NumberConverter
    {
        private INumberDictionary _strings;

        public NumberConverter(INumberDictionary strings)
        {
            _strings = strings;
        }

        public string Convert(int number)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (number == 0)
            {
                return _strings.SmallNumbers[number];
            }

            if (number < 0)
            {
                stringBuilder.AppendFormat("{0} {1} ",
                    _strings.Minus, Convert(Math.Abs(number)));

                return stringBuilder.ToString();
            }

            if ((number / 1000000000) > 0)
            {
                stringBuilder.AppendFormat("{0}{1} ",
                    Convert(number / 1000000000), _strings.BigNumbers[1000000000]);
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                stringBuilder.AppendFormat("{0}{1} ",
                    Convert(number / 1000000), _strings.BigNumbers[1000000]);
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                stringBuilder.AppendFormat("{0}{1} ",
                    Convert(number / 1000), _strings.BigNumbers[1000]);
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                stringBuilder.AppendFormat("{0}{1} ",
                    Convert(number / 100), _strings.BigNumbers[100]);
                number %= 100;
            }

            if (stringBuilder.Length > 0)
            {
                stringBuilder.AppendFormat("{0} ", _strings.And);
            }

            if (number < 20)
            {
                stringBuilder.AppendFormat("{0} ", _strings.SmallNumbers[number]);
            }
            else
            {
                stringBuilder.AppendFormat("{0}", _strings.Tens[number / 10]);

                if ((number % 10) > 0)
                {
                    stringBuilder.AppendFormat("-{0} ",
                        _strings.SmallNumbers[number % 10]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
