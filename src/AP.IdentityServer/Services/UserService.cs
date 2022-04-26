using AP.IdentityServer.Domain.DbContexts;
using AP.IdentityServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AP.IdentityServer.Services
{
    public class UserService : IUserService
    {
        private readonly IdentityDbContext _context;

        public UserService(
            IdentityDbContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }          

        public async Task<bool> IsUserActive(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                return false;
            }

            var user = await GetUserBySubjectAsync(subject);

            if (user == null)
            {
                return false;
            }

            return user.Status == Domain.Enum.Status.Active;
        }
         
        public async Task<bool> ValidateClearTextCredentialsAsync(string userName,
          string password)
        {
            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = await GetUserByUserNameAsync(userName);

            if (user == null)
            {
                return false;
            }

            if (user.Status != Domain.Enum.Status.Active)
            {
                return false;
            }

            // Validate credentials
            return (user.Password == password);
        }

        
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return await _context.Users
                 .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<UserClaim>> GetUserClaimsBySubjectAsync(string subject)
        {
            //if (string.IsNullOrWhiteSpace(subject))
            //{
            //    throw new ArgumentNullException(nameof(subject));
            //}

            //return await _context.UserClaims.Where(u => u.User.Subject == subject).ToListAsync();
            return null;
        }

        public async Task<User> GetUserBySubjectAsync(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return await _context.Users.FirstOrDefaultAsync(u => u.Subject == subject);
        }
    }
}
