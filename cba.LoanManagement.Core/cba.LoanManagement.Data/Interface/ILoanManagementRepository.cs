using cba.LoanManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace cba.LoanManagement.Data.Interface
{
   public interface ILoanManagementRepository
    {      
        List<LoanList> GetLoanList(int? acNumbwe);

        List<LoanDetails> Getloan();
    }
}
