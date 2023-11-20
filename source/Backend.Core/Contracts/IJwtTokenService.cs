using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core.Contracts
{
    public interface IJwtTokenService
    {
        public string CreateAccessToken(string userName, string userId, IEnumerable<string> roles);
        public string CreateRefreshToken(string userId);
        public bool TryParseRefreshToken(string refreshToken, out ClaimsPrincipal? claims);
    }
}
