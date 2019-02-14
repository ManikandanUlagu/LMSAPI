using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cba.LoadManagement.BusinessLogic.Interface;
using cba.LoanManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cba.LoanManagement.Core.Api.Controllers
{
    [Route("api/Loan/V1")]
    public class LoanManagementController : ControllerBase
    {
        private readonly ILoanManagement _loanManagement;
        public LoanManagementController(ILoanManagement loanManagement)
        {
            _loanManagement = loanManagement;
        }
        /// <summary>
        /// Get Date
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Loan/GetDate")]
        public IActionResult Get()

        {
            var response = new IComparable[]
                {HttpStatusCode.OK, DateTime.Now.ToString(CultureInfo.InvariantCulture)};

            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/LoanList")]
        public IActionResult GetLoanList(int? acNumber)
        {
            if (acNumber.HasValue)
            {
                var response = _loanManagement.GetLoanList(acNumber);

                if (response != null)
                {
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest();
            }
            return new ContentResult { StatusCode = (int)HttpStatusCode.NoContent };

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Getloan")]
        public IActionResult Getloan()
        {
            var response = _loanManagement.Getloan();
           
            if (response != null)
            {
                return Ok(response);
            }
            else
                { return BadRequest(); }
           
        }

    }



}