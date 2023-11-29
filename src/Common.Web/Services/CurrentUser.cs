using System.Security.Claims;
using Common.Application.Interfaces;

namespace Common.Web.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue("username");

    public bool? IsInRole (string role)
        => httpContextAccessor.HttpContext?.User?.IsInRole(role);

    public IEnumerable<string>? Policies()
        => httpContextAccessor.HttpContext?.User?.FindAll("profile").Select(c => c.Value).ToList();
}
