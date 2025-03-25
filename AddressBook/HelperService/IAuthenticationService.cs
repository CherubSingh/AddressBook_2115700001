using RepositoryLayer.Entity;
using System.Security.Claims;

namespace AddressBook.HelperService
{
    public interface IAuthenticationService
    {
        string GenerateToken(User user);
        string GenerateResetToken(User user);
        ClaimsPrincipal ValidateToken(string token);
    }
}
