namespace Common.Application.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(Guid userId, CancellationToken token);

    Task<bool> IsInRoleAsync(Guid userId, string role, CancellationToken token);

    Task<bool> AuthorizeAsync(Guid userId, string policyName, CancellationToken token);
}
