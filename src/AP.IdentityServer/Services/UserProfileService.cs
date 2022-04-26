using AP.IdentityServer.Services;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Marvin.IDP.Services
{
    public class UserProfileService : IProfileService
    {
        private readonly IUserService _localUserService;

        public UserProfileService(IUserService localUserService)
        {
            _localUserService = localUserService ??
                throw new ArgumentNullException(nameof(localUserService));
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            var claimsForUser = (await _localUserService.GetUserClaimsBySubjectAsync(subjectId))
                .ToList();

            //context.AddRequestedClaims(
            //    claimsForUser.Select(c => new Claim(c.Type, c.Value)).ToList()); //T-TEMP
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var subjectId = context.Subject.GetSubjectId();
            context.IsActive = await _localUserService.IsUserActive(subjectId);
        }
    }
}
