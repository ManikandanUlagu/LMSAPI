using System;
using System.Collections.Generic;
using System.Text;
using cba.LoanManagement.Model;
namespace cba.LoadManagement.BusinessLogic.Interface
{
   public interface ILoanManagement
    {
   
        List<LoanList> GetLoanList(int? loanACNumber);
        LoanDetails GetCreditDetails(int? loanACNumber);
        List<LoanDetails> Getloan();
    }
}
