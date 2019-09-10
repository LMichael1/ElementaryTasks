using System;

namespace Validation
{
    public class ArgsValidator : IArgsValidator
    {
        #region Fields

        protected readonly int _argsLength;

        #endregion

        #region Properties

        public string[] Args { get; set; } 

        #endregion

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
            bool result = true;

            foreach (var value in values)
            {
                if (!int.TryParse(value, out _))
                {
                    result = false;
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
            bool result = true;

            foreach (var value in values)
            {
                if (!double.TryParse(value, out _))
                {
                    result = false;
                }
            }

            return result;
        }

        public virtual bool IsNumberOfArgsValid()
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
