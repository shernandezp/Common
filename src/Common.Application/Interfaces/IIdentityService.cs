using Common.Application.Models;

namespace Common.Application.Interfaces;

public interface IIdentityService
{
    string? GetUserNameAsync(string userId);

    bool IsInRoleAsync(string role);

    bool AuthorizeAsync(string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);
}
