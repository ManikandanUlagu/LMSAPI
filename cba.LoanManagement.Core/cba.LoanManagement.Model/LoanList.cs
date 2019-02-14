using System;
using System.Collections.Generic;
using System.Text;

namespace cba.LoanManagement.Model
{
   public class LoanList
    {
        public int ACNumber { get; set; }
        public string CustName { get; set; }
        public string LoanACNumber { get; set; }
        public string LoanName { get; set; }
        public Double Balance { get; set; }
    }
}
