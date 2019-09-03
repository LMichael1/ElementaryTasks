using System;

namespace Validation
{
    public class ArgsValidator : IArgsValidator
    {
        #region Private fields

        private readonly int _argsLength;
        protected readonly string[] _args;

        #endregion

        public ArgsValidator(string[] args, int argsLength)
        {
            _args = args;
            _argsLength = argsLength;
        }

        public bool IsInteger(int argIndex)
        {
            return int.TryParse(_args[argIndex], out _);
        }

        public bool IsInteger(string value)
        {
            return int.TryParse(value, out _);
        }

        public bool IsDouble(int argIndex)
        {
            return double.TryParse(_args[argIndex], out _);
        }

        public bool IsDouble(string value)
        {
            return double.TryParse(value, out _);
        }

        public bool IsNumberOfArgsValid()
        {
            return _args.Length == _argsLength;
        }

        public bool IsArgsEmpty()
        {
            return _args.Length == 0;
        }

        public bool IsArgsIntegers()
        {
            bool result = true;
            for (int i = 0; i < _args.Length; i++)
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
            for (int i = 0; i < _args.Length; i++)
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
