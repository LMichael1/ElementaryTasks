using System;

namespace Validation
{
    public class ArgsValidator : IArgsValidator
    {
        #region Private fields

        private readonly int _argsLength;

        #endregion

        public string[] Args { get; set; }

        public ArgsValidator(string[] args, int argsLength)
        {
            Args = args;
            _argsLength = argsLength;
        }

        public bool IsInteger(int argIndex)
        {
            return int.TryParse(Args[argIndex], out _);
        }

        public bool IsIntegers(params string[] values)
        {
            bool result = false;

            foreach (var value in values)
            {
                if (int.TryParse(value, out _))
                {
                    result = true;
                }
            }

            return result;
        }

        public bool IsDouble(int argIndex)
        {
            return double.TryParse(Args[argIndex], out _);
        }

        public bool IsDoubles(params string[] values)
        {
            bool result = false;

            foreach (var value in values)
            {
                if (double.TryParse(value, out _))
                {
                    result = true;
                }
            }

            return result;
        }

        public bool IsNumberOfArgsValid()
        {
            return Args.Length == _argsLength;
        }

        public bool IsArgsEmpty()
        {
            return Args.Length == 0;
        }

        public bool IsArgsIntegers()
        {
            bool result = true;
            for (int i = 0; i < Args.Length; i++)
            {
                if (!IsInteger(i))
                {
                    result = false;
                }
            }

            return result;
        }

        public bool IsArgsDoubles()
        {
            bool result = true;
            for (int i = 0; i < Args.Length; i++)
            {
                if (!IsDouble(i))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
