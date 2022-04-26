using AP.IdentityServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AP.IdentityServer.Services
{
    public interface IUserService
    { 
        Task<bool> ValidateClearTextCredentialsAsync(
            string userName, 
            string password);

        Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(
            string subject);

        Task<User> GetUserByUserNameAsync(
            string userName);
        Task<User> GetUserBySubjectAsync(
            string subject);        
 
        Task<bool> IsUserActive(
            string subject);
    }
}
