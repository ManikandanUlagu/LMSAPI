using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using cba.LoanManagement.Model;
using System;
using cba.LoanManagement.Data.Interface;
using System.Data;
using System.Data.SqlClient;
using cba.LoanManagement.Common;

namespace cba.LoanManagement.Data
{
    public class LoanManagementRepository : ILoanManagementRepository
    {
        private readonly AppSetting _appSettingAccessor;
        public LoanManagementRepository(IOptions<AppSetting> appSettingAccessor)
        {
            _appSettingAccessor = appSettingAccessor.Value;
        }

        public List<LoanDetails> Getloan()
        {
            var connectionString = _appSettingAccessor.DatabaseConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // var response = db.Query<LoanList>(SqlConstants.LoanList, new { AcNumber = acNumber }).ToList();
                List<LoanDetails> listLoad = new List<LoanDetails>();
                listLoad.Add(new LoanDetails() { Balance = 48, LoanName = "Loan1 # 12345678", Showdetails = false, Interest = 24, Payout = 43, Repay = 22 });
                listLoad.Add(new LoanDetails() { Balance = 55, LoanName = "Loan2 # 12345673", Showdetails = false, Interest = 27, Payout = 45, Repay = 23 });
                listLoad.Add(new LoanDetails() { Balance = 67, LoanName = "Loan3 # 12345675", Showdetails = false, Interest = 24, Payout = 43, Repay = 26 });
                return listLoad;
            }
        }

        public List<LoanList> GetLoanList(int? acNumber)
        {
            var connectionString = _appSettingAccessor.DatabaseConnectionString;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                // var response = db.Query<LoanList>(SqlConstants.LoanList, new { AcNumber = acNumber }).ToList();
                return new List<LoanList>(); 
            }
        }
       
        

        
    }
}
