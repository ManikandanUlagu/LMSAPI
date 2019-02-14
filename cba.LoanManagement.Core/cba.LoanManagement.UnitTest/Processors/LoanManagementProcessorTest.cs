using Moq;
using cba.LoadManagement.BusinessLogic;
using cba.LoanManagement.Data.Interface;
using cba.LoanManagement.Model;
using System;
using System.Collections.Generic;
using Xunit;
namespace cba.LoanManagement.UnitTest.Processors
{
   public  class LoanManagementProcessorTest
    {
        private readonly Mock<ILoanManagementRepository> _repository;
        private readonly List<LoanDetails> _loandetails;

        public LoanManagementProcessorTest()
        {
            _repository = new Mock<ILoanManagementRepository>();

            _loandetails = new List<LoanDetails>
                {
                    new LoanDetails
                    {
                        Balance = 48, LoanName = "Loan1 # 12345678", Showdetails = false, Interest = 24, Payout = 43, Repay = 22
                    },
                    new LoanDetails
                    {
                        Balance = 55, LoanName = "Loan2 # 12345673", Showdetails = false, Interest = 27, Payout = 45, Repay = 23
                    },
                    new LoanDetails
                    {
                    Balance = 67, LoanName = "Loan3 # 12345675", Showdetails = false, Interest = 24, Payout = 43, Repay = 26
                   }
                };
        }
        [Fact]
        public void TestIGetloan()
        {
            //Arrange
       
            _repository.Setup(rep => rep.Getloan()).Returns(_loandetails);
            var processor = new cba.LoadManagement.BusinessLogic.LoanManagement(_repository.Object);

            //Act
            var output = processor.Getloan();
            Assert.NotNull(output);
            _repository.VerifyAll();
            //Assert
            Assert.NotEmpty(output);
        }
        
        
        [Fact]
        public void TestIGetloan_ThrowsException()
        {
            _repository.Setup(rep => rep.Getloan()).Throws(new Exception());
            var processor = new  cba.LoadManagement.BusinessLogic.LoanManagement(_repository.Object);

            //Act
            var exception = Record.Exception(() => processor.Getloan());

            //Assert
            Assert.IsType<Exception>(exception);
            Assert.Equal("Exception of type 'System.Exception' was thrown.", exception.Message);
        }
    }
}
