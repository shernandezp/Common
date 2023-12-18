namespace Common.Domain.Extensions;

public static class PasswordExtensions
{
    public static string HashPassword(this string value, DateTime passwordReset) 
        => BCrypt.Net.BCrypt.HashPassword(value, passwordReset.FormatPasswordReset());

    public static bool VerifyHashedPassword(this string hashedPassword, string password)
        => BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}
