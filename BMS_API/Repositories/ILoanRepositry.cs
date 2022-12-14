using BMS_API.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS_API.Repositories
{
    public interface ILoanRepositry
    {
        Task<LoanDetail> GetLoanAsync(int loanId);
        Task<List<LoanDetail>> GetAllLoanAsync(string userName);
        Task<List<LoanDetail>> GetAllAsync();
        Task<bool> UpdateStatusAsync(int loanId, string status);
        Task<bool> SaveLoanDeatilAsync(LoanDetail loanDetail);
    }
}
