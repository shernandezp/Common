using Common.Application.Interfaces;
using Common.Application.Models;

namespace Common.Infrastructure.Identity;

public class IdentityService(IUser user) : IIdentityService
{
    public string? GetUserNameAsync(string userId)
    {
        return user.Id;
    }

    public Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        /*var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);*/
        throw new NotImplementedException();
    }

    public bool IsInRoleAsync(string role)
    {
        var result = user.IsInRole(role);
        return result != null && result.Value;
    }

    public bool AuthorizeAsync(string policyName)
    {
        var policies = user.Policies();
        return policies != null && policies.Any(p => p.Equals(policyName));
    }

    public Task<Result> DeleteUserAsync(string userId)
    {
        /*var user = userManager.Users.SingleOrDefault(u => u.Id == userId);
        return user != null ? await DeleteUserAsync(user) : Result.Success();*/
        throw new NotImplementedException();
    }
}
