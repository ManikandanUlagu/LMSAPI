using System;
using System.Collections.Generic;
using System.Text;

namespace cba.LoanManagement.Model
{
   public class LoanDetails
    {
      
        public string LoanName { get; set; }
        public Double Balance { get; set; }
        public Boolean Showdetails { get; set; }
        public Double Interest { get; set; }
        public Double Repay { get; set; }
        public Double Payout { get; set; }
    }
}
