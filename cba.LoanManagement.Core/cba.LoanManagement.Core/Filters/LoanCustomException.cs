using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cba.LoanManagement.Core.Api.Filters
{
    public class LoanCustomException : Exception
    {
        public LoanCustomException()
        { }

        public LoanCustomException(string message)
            : base(message)
        { }

        public LoanCustomException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
