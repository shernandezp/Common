namespace Common.Application.Interfaces;

public interface IUser
{
    string? Id { get; }
    bool? IsInRole(string role);
    IEnumerable<string>? Policies();
}
