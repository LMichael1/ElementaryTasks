using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace FileParser
{
    public class ParserArgsValidator : ArgsValidator, IParserArgsValidator
    {
        #region Fields

        private readonly int _argsLengthReplace;  

        #endregion

        public ParserArgsValidator(string[] args, int argsLength, int argsLengthReplace) 
            : base(args, argsLength)
        {
            _argsLengthReplace = argsLengthReplace;
        }

        public override bool IsNumberOfArgsValid()
        {
            return Args.Length == _argsLength || Args.Length == _argsLengthReplace;
        }

        public ArgsValidatorResult ValidateArgs()
        {
            if (IsArgsEmpty())
            {
                return ArgsValidatorResult.Empty;
            }

            if (!IsNumberOfArgsValid())
            {
                return ArgsValidatorResult.InvalidNumberOfArgs;
            }

            if (!File.Exists(Args[0]))
            {
                return ArgsValidatorResult.InvalidValue;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
