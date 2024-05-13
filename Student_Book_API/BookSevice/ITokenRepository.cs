using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Student_Book_API.BookSevice
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> list);
    }
}
