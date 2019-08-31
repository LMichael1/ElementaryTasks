using System;

namespace Validation
{
    public class Validator : IValidator
    {
        #region Private fields

        private readonly int _argsLength;
        
        #endregion

        public Validator(int argsLength)
        {
            _argsLength = argsLength;
        }

        public virtual bool IsNumber(string number)
        {
            return int.TryParse(number, out _);
        }

        public bool IsNumberOfArgsValid(string[] args)
        {
            return args.Length == _argsLength;
        }

        public bool IsArgsEmpty(string[] args)
        {
            return args.Length == 0;
        }

        public bool IsArgsNumbers(params string[] args)
        {
            bool result = true;
            foreach (var arg in args)
            {
                if (!IsNumber(arg))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
