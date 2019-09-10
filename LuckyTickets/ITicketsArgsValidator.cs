using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;

namespace LuckyTickets
{
    interface ITicketsArgsValidator : IArgsValidator
    {
        ArgsValidatorResult ValidateArgs();
    }
}

