using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace LuckyTickets
{
    class TicketsArgsValidator : ArgsValidator, ITicketsArgsValidator
    {
        public TicketsArgsValidator(string[] args, int argsLength) : base(args, argsLength)
        {

        }

        public bool IsAlgorithmValid()
        {
            return Args[1].ToUpper() == StringConstants.MOSCOW || 
                Args[1].ToUpper() == StringConstants.PETER;
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

            if (!IsAlgorithmValid())
            {
                return ArgsValidatorResult.InvalidTypeOfArgs;
            }

            return ArgsValidatorResult.Success;
        }
    }
}
