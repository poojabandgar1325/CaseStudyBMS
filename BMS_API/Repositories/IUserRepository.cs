using BMS_API.Models.Domains;
using System.Threading.Tasks;

namespace BMS_API.Repositories
{
    public interface IUserRepository
    {
        
        Task<UserDetail> GetUserAsync(string userName);
        Task<bool> SaveUserDeatilAsync(UserDetail userDetail);

        Task<bool> UpdateUserAsync(string userName, UserDetail userDetail);

        Task<int> ValidateUserCredAsync(string userName, string password);
    }
}