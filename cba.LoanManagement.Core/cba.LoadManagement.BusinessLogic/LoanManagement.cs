using cba.LoadManagement.BusinessLogic.Interface;
using cba.LoanManagement.Data.Interface;
using cba.LoanManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cba.LoadManagement.BusinessLogic
{
    public class LoanManagement : ILoanManagement
    {
        
        private readonly ILoanManagementRepository _loanManagementRepository;
        public LoanManagement(ILoanManagementRepository loanManagementRepository)
        {
            _loanManagementRepository = loanManagementRepository;
        }

        public LoanDetails GetCreditDetails(int? acNumber)
        {
           
            var listLoan = _loanManagementRepository.GetLoanList(acNumber);
            throw new NotImplementedException();
        }

        public List<LoanDetails> Getloan()
        {
            return _loanManagementRepository.Getloan();
        }

        public List<LoanList> GetLoanList(int? loanACNumber)
        {
            throw new NotImplementedException();
        }
    }
}
